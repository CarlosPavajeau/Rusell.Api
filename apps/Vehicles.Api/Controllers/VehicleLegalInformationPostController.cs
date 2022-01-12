using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rusell.Vehicles.Api.Controllers.Requests;
using Rusell.Vehicles.Application.LegalInformation.Create;
using Rusell.Vehicles.Domain;

namespace Rusell.Vehicles.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/vehicles/{licencePlate}/legal-information")]
public class VehicleLegalInformationPostController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<VehicleLegalInformationPostController> _logger;

    public VehicleLegalInformationPostController(IMediator mediator,
        ILogger<VehicleLegalInformationPostController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> CreateLegalInformation(string licencePlate,
        [FromBody] CreateVehicleLegalInformationRequest request)
    {
        try
        {
            var command = request.Adapt<CreateVehicleLegalInformationCommand>();
            command.LicensePlate = licencePlate;

            await _mediator.Send(command);
        }
        catch (VehicleNotFound)
        {
            return NotFound();
        }
        catch (DbUpdateException e)
        {
            _logger.LogError(e, "Failed to create vehicle legal information");
            return BadRequest();
        }

        return Ok();
    }
}
