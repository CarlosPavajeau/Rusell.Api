using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rusell.Vehicles.Application;
using Rusell.Vehicles.Application.SearchAll;

namespace Rusell.Vehicles.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/vehicles/companies/{companyId:guid}/vehicles")]
public class CompanyVehiclesGetController : ControllerBase
{
    private readonly IMediator _mediator;

    public CompanyVehiclesGetController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<VehicleResponse>>> GetVehicles(Guid companyId)
    {
        var vehicles = await _mediator.Send(new SearchAllVehiclesQuery(companyId));
        return Ok(vehicles);
    }
}
