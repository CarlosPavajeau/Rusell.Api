using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rusell.BankDrafts.Application;
using Rusell.BankDrafts.Application.SearchAllByReceiver;

namespace Rusell.BankDrafts.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/bank-drafts/by-receiver/{receiverId}")]
public class BankDraftsByReceiverGetController : ControllerBase
{
    private readonly IMediator _mediator;

    public BankDraftsByReceiverGetController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BankDraftResponse>>> GetBankDraftsByReceiver(string receiverId)
    {
        var bankDrafts = await _mediator.Send(new SearchAllBankDraftsByReceiverQuery(receiverId));
        return Ok(bankDrafts);
    }
}
