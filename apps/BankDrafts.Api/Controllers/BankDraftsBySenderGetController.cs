using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rusell.BankDrafts.Application;
using Rusell.BankDrafts.Application.SearchAllBySender;

namespace Rusell.BankDrafts.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/bank-drafts/by-sender/{senderId}")]
public class BankDraftsBySenderGetController : ControllerBase
{
    private readonly IMediator _mediator;

    public BankDraftsBySenderGetController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BankDraftResponse>>> GetBankDraftsBySender(string senderId)
    {
        var bankDrafts = await _mediator.Send(new SearchAllBankDraftsBySenderQuery(senderId));
        return Ok(bankDrafts);
    }
}
