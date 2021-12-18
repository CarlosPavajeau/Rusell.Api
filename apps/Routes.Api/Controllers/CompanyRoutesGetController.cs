using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rusell.Routes.Application;
using Rusell.Routes.Application.SearchAllByCompany;

namespace Rusell.Routes.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/routes/companies/{companyId:guid}/routes")]
public class CompanyRoutesGetController : ControllerBase
{
    private readonly ILogger<CompanyRoutesGetController> _logger;
    private readonly IMediator _mediator;

    public CompanyRoutesGetController(ILogger<CompanyRoutesGetController> logger, IMediator mediator)
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
}
