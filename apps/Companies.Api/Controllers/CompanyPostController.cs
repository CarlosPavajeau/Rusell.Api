using System.Security.Claims;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rusell.Companies.Api.Controllers.Requests;
using Rusell.Companies.Application.Create;

namespace Rusell.Companies.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/companies")]
public class CompanyPostController : ControllerBase
{
    private readonly ILogger<CompanyPostController> _logger;
    private readonly IMediator _mediator;

    public CompanyPostController(ILogger<CompanyPostController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCompany([FromBody] CreateCompanyRequest request)
    {
        try
        {
            var commandUserId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            if (commandUserId is null)
                return Unauthorized();

            var command = request.Adapt<CreateCompanyCommand>();
            command.UserId = commandUserId;
            await _mediator.Send(command);
        }
        catch (DbUpdateException e)
        {
            _logger.LogError(e, "Error creating company");
            return BadRequest();
        }

        return Ok();
    }
}
