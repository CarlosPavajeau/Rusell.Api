using Rusell.Clients.Application;
using Rusell.Clients.Application.Find;

namespace Rusell.Clients.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/clients/{clientId}")]
public class ClientGetController : ControllerBase
{
    private readonly ILogger<ClientGetController> _logger;
    private readonly IMediator _mediator;

    public ClientGetController(ILogger<ClientGetController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ClientResponse>> GetClient(string clientId)
    {
        try
        {
            var client = await _mediator.Send(new FindClientQuery(clientId));
            if (client is null)
            {
                return NotFound();
            }

            return Ok(client);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error getting client");
            return BadRequest();
        }
    }
}
