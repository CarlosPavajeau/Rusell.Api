using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rusell.Routes.Api.Controllers.Requests;
using Rusell.Routes.Application;
using Rusell.Routes.Application.Create;
using Rusell.Routes.Application.SearchAllByCompany;

namespace Rusell.Routes.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/routes/companies/{companyId:guid}/[controller]")]
public class RoutesController : ControllerBase
{
    private readonly ILogger<RoutesController> _logger;
    private readonly IMediator _mediator;

    public RoutesController(ILogger<RoutesController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<RouteResponse>>> GetRoutes(Guid companyId)
    {
        var routes = await _mediator.Send(new SearchAllRoutesByCompanyQuery(companyId));
        return Ok(routes);
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
