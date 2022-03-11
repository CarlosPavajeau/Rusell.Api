using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rusell.TransportSheets.Application;
using Rusell.TransportSheets.Application.FindCurrent;

namespace Rusell.TransportSheets.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/transport-sheets/companies/{companyId:guid}/transport-sheets/current")]
public class GetCurrentController : ControllerBase
{
    private readonly IMediator _mediator;

    public GetCurrentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<TransportSheetResponse>> GetCurrent(Guid companyId)
    {
        var response = await _mediator.Send(new FindCurrentTransportSheetQuery(companyId));

        return response == null ? NotFound() : Ok(response);
    }
}
