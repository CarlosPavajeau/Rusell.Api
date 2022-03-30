using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rusell.Tickets.Api.Controllers.Requests;
using Rusell.Tickets.Application.Create;

namespace Rusell.Tickets.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/tickets/transport-sheets/{transportSheetId:guid}/tickets")]
public class PostController : ControllerBase
{
    private readonly ILogger<PostController> _logger;
    private readonly IMediator _mediator;

    public PostController(ILogger<PostController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateTicket(Guid transportSheetId, [FromBody] CreateTicketRequest request)
    {
        try
        {
            var command = request.Adapt<CreateTicketCommand>();
            command.TransportSheetId = transportSheetId;

            var ticketId = await _mediator.Send(command);
            return Ok(ticketId);
        }
        catch (DbUpdateException e)
        {
            _logger.LogError(e, "Error creating ticket");
            return BadRequest();
        }
    }
}
