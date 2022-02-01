using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rusell.Parcels.Application;
using Rusell.Parcels.Application.SearchAllByReceiver;
using Rusell.Parcels.Application.SearchAllByReceiverAndState;
using Rusell.Parcels.Domain;

namespace Rusell.Parcels.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/parcels/by-receiver/{receiverId}")]
public class ParcelsByReceiverGetController : ControllerBase
{
    private readonly IMediator _mediator;

    public ParcelsByReceiverGetController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ParcelResponse>>> GetParcelsByReceiver(string receiverId,
        [FromQuery] ParcelState? state)
    {
        if (state.HasValue)
        {
            var parcelsByState =
                await _mediator.Send(new SearchAllParcelsByReceiverAndStateQuery(receiverId, state.Value));
            return Ok(parcelsByState);
        }

        var parcels = await _mediator.Send(new SearchAllParcelsByReceiverQuery(receiverId));
        return Ok(parcels);
    }
}
