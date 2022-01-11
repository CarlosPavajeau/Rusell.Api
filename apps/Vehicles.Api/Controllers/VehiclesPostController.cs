using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rusell.Vehicles.Api.Controllers.Requests;
using Rusell.Vehicles.Application.Create;

namespace Rusell.Vehicles.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/vehicles/companies/{companyId:guid}/vehicles")]
public class VehiclesPostController : ControllerBase
{
    private readonly ILogger<VehiclesPostController> _logger;
    private readonly IMediator _mediator;

    public VehiclesPostController(ILogger<VehiclesPostController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateVehicle(Guid companyId, [FromBody] CreateVehicleRequest request)
    {
        try
        {
            var command = request.Adapt<CreateVehicleCommand>();
            command.CompanyId = companyId;

            await _mediator.Send(command);
        }
        catch (DbUpdateException e)
        {
            _logger.LogError(e, "Error creating vehicle");
            return BadRequest();
        }

        return Ok();
    }
}
