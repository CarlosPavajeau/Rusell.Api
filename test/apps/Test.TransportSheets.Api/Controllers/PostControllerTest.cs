using System;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Rusell.Test.Shared.Domain;
using Rusell.TransportSheets.Api;
using Rusell.TransportSheets.Api.Controllers.Requests;
using Xunit;

namespace Rusell.Test.TransportSheets.Api.Controllers;

public class PostControllerTest : TransportSheetsApplicationTestCase
{
    public PostControllerTest(TransportSheetsWebApplicationFactory<Program> factory) : base(factory)
    {
        CreateAuthenticatedClient();
    }

    [Fact]
    public async Task Save_Should_Return_Ok()
    {
        var dispatcherId = await CreateDispatcher();
        var createRequest = new CreateTransportSheetRequest(
            10,
            WordMother.Random(),
            dispatcherId,
            Guid.NewGuid()
        );

        var createResponse =
            await Client.PostAsJsonAsync($"api/transport-sheets/companies/{Guid.NewGuid().ToString()}/transport-sheets",
                createRequest);

        createResponse.EnsureSuccessStatusCode();
    }
}
