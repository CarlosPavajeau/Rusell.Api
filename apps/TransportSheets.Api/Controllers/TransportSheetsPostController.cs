using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rusell.TransportSheets.Api.Controllers.Requests;
using Rusell.TransportSheets.Application.Create;

namespace Rusell.TransportSheets.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/transport-sheets/companies/{companyId:guid}/transport-sheets")]
public class TransportSheetsPostController : ControllerBase
{
    private readonly ILogger<TransportSheetsPostController> _logger;
    private readonly IMediator _mediator;

    public TransportSheetsPostController(ILogger<TransportSheetsPostController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateTransportSheet(Guid companyId,
        [FromBody] CreateTransportSheetRequest request)
    {
        try
        {
            var command = request.Adapt<CreateTransportSheetCommand>();
            command.CompanyId = companyId;

            var transportSheetId = await _mediator.Send(command);
            return Ok(transportSheetId);
        }
        catch (DbUpdateException e)
        {
            _logger.LogError(e, "Error creating transport sheet");
            return BadRequest();
        }
    }
}
