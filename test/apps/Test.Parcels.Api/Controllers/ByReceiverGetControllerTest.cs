using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Rusell.Parcels.Api;
using Rusell.Parcels.Api.Controllers.Requests;
using Rusell.Parcels.Application;
using Rusell.Test.Shared.Domain;
using Xunit;

namespace Rusell.Test.Parcels.Api.Controllers;

public class ByReceiverGetControllerTest : ParcelsContextApplicationTestCase
{
    public ByReceiverGetControllerTest(ParcelsWebApplicationFactory<Program> factory) : base(factory)
    {
        CreateAuthenticatedClient();
    }

    [Fact]
    public async Task GetBySender_Should_Return_All_Parcels_By_Receiver()
    {
        var sender = await CreateCustomer();
        var receiver = await CreateCustomer();
        var dispatcher = await CreateDispatcher();
        var company = await CreateCompany();

        var createParcelRequest = new CreateParcelRequest(
            WordMother.Random(),
            MotherCreator.Random().Decimal(10, 10000),
            WordMother.Random(),
            dispatcher.Id.Value,
            sender.Id.Value,
            receiver.Id.Value
        );

        var createResponse =
            await Client.PostAsJsonAsync($"api/parcels/companies/{company.Id.Value}/parcels", createParcelRequest);
        createResponse.EnsureSuccessStatusCode();

        var response = await Client.GetAsync($"api/parcels/by-receiver/{receiver.Id.Value}");
        response.EnsureSuccessStatusCode();

        var parcels = await response.Content.ReadFromJsonAsync<List<ParcelResponse>>();

        parcels.Should().NotBeEmpty();
    }
}
