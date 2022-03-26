using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rusell.BankDrafts.Api.Controllers.Requests;

namespace Rusell.BankDrafts.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/bank-drafts/companies/{companyId:guid}/bank-drafts")]
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
    public async Task<IActionResult> CreateBankDraft(Guid companyId, [FromBody] CreateBankDraftRequest request)
    {
        try
        {
            var command = request.Adapt<CreateBankDraftCommand>();
            command.CompanyId = companyId;

            await _mediator.Send(command);
        }
        catch (DbUpdateException e)
        {
            _logger.LogError(e, "Error creating bank draft");
            return BadRequest();
        }

        return Ok();
    }
}
