using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rusell.Routes.Api.Controllers.Requests;
using Rusell.Routes.Application.Create;

namespace Rusell.Routes.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/routes/companies/{companyId:guid}/routes")]
public class RoutesPostController : ControllerBase
{
    private readonly ILogger<RoutesPostController> _logger;
    private readonly IMediator _mediator;

    public RoutesPostController(ILogger<RoutesPostController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateRoute(Guid companyId, [FromBody] CreateRouteRequest request)
    {
        try
        {
            var command = request.Adapt<CreateRouteCommand>();
            command.CompanyId = companyId;

            await _mediator.Send(command);
        }
        catch (DbUpdateException e)
        {
            _logger.LogError(e, "Error creating route");
            return BadRequest();
        }

        return Ok();
    }
}
