using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rusell.Tickets.Application;
using Rusell.Tickets.Application.SearchAllByTransportSheet;

namespace Rusell.Tickets.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/tickets/transport-sheets/{transportSheetId:guid}/tickets")]
public class TicketsByTransportSheetGetController : ControllerBase
{
    private readonly IMediator _mediator;

    public TicketsByTransportSheetGetController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TicketResponse>>> GetTickets(Guid transportSheetId)
    {
        var tickets = await _mediator.Send(new SearchAllTicketsByTransportSheetQuery(transportSheetId));
        return Ok(tickets);
    }
}
