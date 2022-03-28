using System;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Rusell.Parcels.Api;
using Rusell.Parcels.Api.Controllers.Requests;
using Rusell.Test.Shared.Domain;
using Xunit;

namespace Rusell.Test.Parcels.Api.Controllers;

public class PostControllerTest : ParcelsContextApplicationTestCase
{
    public PostControllerTest(ParcelsWebApplicationFactory<Program> factory) : base(factory)
    {
        CreateAuthenticatedClient();
    }

    [Fact]
    public async Task CreateParcel_Should_Return_Ok()
    {
        var createParcelRequest = new CreateParcelRequest(
            WordMother.Random(),
            MotherCreator.Random().Decimal(1, 10000),
            WordMother.Random(),
            WordMother.Random(),
            WordMother.Random(),
            WordMother.Random()
        );

        var response =
            await Client.PostAsJsonAsync($"api/parcels/companies/{Guid.NewGuid()}/parcels", createParcelRequest);

        response.EnsureSuccessStatusCode();
    }
}
