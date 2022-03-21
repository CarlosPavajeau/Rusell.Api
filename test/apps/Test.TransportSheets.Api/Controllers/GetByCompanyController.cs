using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Rusell.Test.Shared.Domain;
using Rusell.TransportSheets.Api;
using Rusell.TransportSheets.Api.Controllers.Requests;
using Rusell.TransportSheets.Application;
using Xunit;

namespace Rusell.Test.TransportSheets.Api.Controllers;

public class GetByCompanyController : TransportSheetsApplicationTestCase
{
    public GetByCompanyController(TransportSheetsWebApplicationFactory<Program> factory) : base(factory)
    {
        CreateAuthenticatedClient();
    }

    [Fact]
    public async Task GetByCompany_Should_Return_All_Transport_Sheets()
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

        var response = await Client.GetAsync($"api/transport-sheets/companies/{companyId}/transport-sheets");
        response.EnsureSuccessStatusCode();

        var transportSheets = await response.Content.ReadFromJsonAsync<IEnumerable<TransportSheetResponse>>();

        transportSheets.Should().NotBeEmpty();
    }
}
