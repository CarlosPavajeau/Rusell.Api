using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rusell.Parcels.Api.Controllers.Requests;
using Rusell.Parcels.Application.Create;

namespace Rusell.Parcels.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/parcels/companies/{companyId:guid}/parcels")]
public class ParcelsPostController : ControllerBase
{
    private readonly ILogger<ParcelsPostController> _logger;
    private readonly IMediator _mediator;

    public ParcelsPostController(ILogger<ParcelsPostController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateParcel(Guid companyId, [FromBody] CreateParcelRequest request)
    {
        try
        {
            var command = request.Adapt<CreateParcelCommand>();
            command.CompanyId = companyId;

            await _mediator.Send(command);
        }
        catch (DbUpdateException e)
        {
            _logger.LogError(e, "Error creating parcel");
            return BadRequest();
        }

        return Ok();
    }
}
