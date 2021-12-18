using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rusell.Routes.Api.Controllers.Requests;
using Rusell.Routes.Application;
using Rusell.Routes.Application.SearchAllByFromTo;

namespace Rusell.Routes.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/routes")]
public class GetRoutesFromToController : ControllerBase
{
    private readonly ILogger<GetRoutesFromToController> _logger;
    private readonly IMediator _mediator;

    public GetRoutesFromToController(ILogger<GetRoutesFromToController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<RouteResponse>>> Get([FromQuery] GetRoutesFromToQueryParams queryParams)
    {
        try
        {
            var query = queryParams.Adapt<SearchAllRoutesByFromToQuery>();
            var routes = await _mediator.Send(query);

            return Ok(routes);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error while getting routes by from and to");
            return StatusCode(500);
        }
    }
}
