using System.Security.Claims;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rusell.Addresses.Api.Controllers.Requests;
using Rusell.Addresses.Application.Create;

namespace Rusell.Addresses.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/addresses")]
public class AddressPostController : ControllerBase
{
    private readonly ILogger<AddressPostController> _logger;
    private readonly IMediator _mediator;

    public AddressPostController(ILogger<AddressPostController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult> SaveAddress([FromBody] CreateAddressRequest request)
    {
        try
        {
            var commandUserId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            if (commandUserId is null)
            {
                return Unauthorized();
            }

            var command = request.Adapt<CreateAddressCommand>();
            command.UserId = commandUserId;
            await _mediator.Send(command);
        }
        catch (DbUpdateException e)
        {
            _logger.LogError(e, "Error saving address");
            return BadRequest();
        }

        return Ok();
    }
}
