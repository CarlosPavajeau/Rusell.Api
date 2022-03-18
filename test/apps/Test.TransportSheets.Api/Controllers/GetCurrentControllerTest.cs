using System;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Rusell.Test.Shared.Domain;
using Rusell.TransportSheets.Api;
using Rusell.TransportSheets.Api.Controllers.Requests;
using Rusell.TransportSheets.Application;
using Xunit;

namespace Rusell.Test.TransportSheets.Api.Controllers;

public class GetCurrentControllerTest : TransportSheetsApplicationTestCase
{
    public GetCurrentControllerTest(TransportSheetsWebApplicationFactory<Program> factory) : base(factory)
    {
        CreateAuthenticatedClient();
    }

    [Fact]
    public async Task GetCurrent_Should_Return_Current_TransportSheet()
    {
        var dispatcherId = await CreateDispatcher();
        var companyId = Guid.NewGuid().ToString();
        var createRequest = new CreateTransportSheetRequest(
            10,
            WordMother.Random(),
            dispatcherId,
            Guid.NewGuid()
        );

        var createResponse =
            await Client.PostAsJsonAsync($"api/transport-sheets/companies/{companyId}/transport-sheets",
                createRequest);

        createResponse.EnsureSuccessStatusCode();

        var response = await Client.GetAsync($"api/transport-sheets/companies/{companyId}/transport-sheets/current");
        response.EnsureSuccessStatusCode();

        var transportSheet = await response.Content.ReadFromJsonAsync<TransportSheetResponse>();

        transportSheet.Should().NotBeNull();
    }
}
