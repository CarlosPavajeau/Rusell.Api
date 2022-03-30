using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rusell.Tickets.Application;
using Rusell.Tickets.Application.SearchAllByClient;

namespace Rusell.Tickets.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/tickets/by-client/{clientId}")]
public class ByClientGetController : ControllerBase
{
    private readonly IMediator _mediator;

    public ByClientGetController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TicketResponse>>> GetTickets(string clientId)
    {
        var tickets = await _mediator.Send(new SearchAllTicketsByClientQuery(clientId));
        return Ok(tickets);
    }
}
