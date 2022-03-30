using System;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Rusell.Tickets.Api;
using Rusell.Tickets.Api.Controllers.Requests;
using Xunit;

namespace Rusell.Test.Tickets.Api.Controllers;

public class PostControllerTest : TicketsContextApplicationTestCase
{
    public PostControllerTest(TicketsWebApplicationFactory<Program> factory) : base(factory)
    {
        CreateAuthenticatedClient();
    }

    [Fact]
    public async Task Save_Should_Return_Ok()
    {
        var transportSheetId = Guid.NewGuid();
        var createTicketRequest = new CreateTicketRequest(
            15000,
            10,
            Guid.NewGuid().ToString()
        );

        var response = await Client.PostAsJsonAsync($"api/tickets/transport-sheets/{transportSheetId}/tickets",
            createTicketRequest);

        response.EnsureSuccessStatusCode();
    }
}
