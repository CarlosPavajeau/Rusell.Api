using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Rusell.Tickets.Api;
using Rusell.Tickets.Api.Controllers.Requests;
using Rusell.Tickets.Application;
using Xunit;

namespace Rusell.Test.Tickets.Api.Controllers;

public class ByTransportSheetGetControllerTest : TicketsContextApplicationTestCase
{
    public ByTransportSheetGetControllerTest(TicketsWebApplicationFactory<Program> factory) : base(factory)
    {
        CreateAuthenticatedClient();
    }

    [Fact]
    public async Task GetAllByTransportSheet_Should_Return_All_Tickets_In_Transport_Sheet()
    {
        var customer = await CreateCustomer();
        var transportSheetId = Guid.NewGuid();

        var createTicketRequest = new CreateTicketRequest(
            15000,
            10,
            customer.Id.Value
        );
        var createResponse = await Client.PostAsJsonAsync($"api/tickets/transport-sheets/{transportSheetId}/tickets",
            createTicketRequest);
        createResponse.EnsureSuccessStatusCode();

        var response = await Client.GetAsync($"api/tickets/transport-sheets/{transportSheetId}/tickets");
        response.EnsureSuccessStatusCode();

        var tickets = await response.Content.ReadFromJsonAsync<List<TicketResponse>>();

        tickets.Should().NotBeEmpty();
    }
}
