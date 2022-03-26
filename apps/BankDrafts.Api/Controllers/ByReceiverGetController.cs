using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rusell.BankDrafts.Application;
using Rusell.BankDrafts.Application.SearchAllByReceiver;
using Rusell.BankDrafts.Application.SearchAllByReceiverAndState;
using Rusell.BankDrafts.Domain;

namespace Rusell.BankDrafts.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/bank-drafts/by-receiver/{receiverId}")]
public class ByReceiverGetController : ControllerBase
{
    private readonly IMediator _mediator;

    public ByReceiverGetController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BankDraftResponse>>> GetBankDraftsByReceiver(string receiverId,
        [FromQuery] BankDraftState? state)
    {
        if (state.HasValue)
        {
            var bankDraftsByState =
                await _mediator.Send(new SearchAllBankDraftsByReceiverAndStateQuery(receiverId, state.Value));
            return Ok(bankDraftsByState);
        }

        var bankDrafts = await _mediator.Send(new SearchAllBankDraftsByReceiverQuery(receiverId));
        return Ok(bankDrafts);
    }
}
