using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Rusell.Clients.Api.Controllers.Requests;

namespace Rusell.Clients.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/clients")]
public class ClientsPostController : ControllerBase
{
    private readonly ILogger<ClientsPostController> _logger;
    private readonly IMediator _mediator;

    public ClientsPostController(ILogger<ClientsPostController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateClient([FromBody] CreateClientRequest request)
    {
        try
        {
            var clientUserId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            if (clientUserId is null) return Unauthorized();

            var command = request.Adapt<CreateClientCommand>();
            command.UserId = clientUserId;
            await _mediator.Send(command);
        }
        catch (DbUpdateException e)
        {
            _logger.LogError(e, "Error creating client");
            return BadRequest();
        }

        return Ok();
    }
}
