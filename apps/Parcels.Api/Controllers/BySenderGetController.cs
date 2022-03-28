using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rusell.Parcels.Application;
using Rusell.Parcels.Application.SearchAllBySender;

namespace Rusell.Parcels.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/parcels/by-sender/{senderId}")]
public class BySenderGetController : ControllerBase
{
    private readonly IMediator _mediator;

    public BySenderGetController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ParcelResponse>>> GetParcelsBySender(string senderId)
    {
        var parcels = await _mediator.Send(new SearchAllParcelsBySenderQuery(senderId));
        return Ok(parcels);
    }
}
