using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rusell.TransportSheets.Application;
using Rusell.TransportSheets.Application.SearchAllByCompany;

namespace Rusell.TransportSheets.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/transport-sheets/companies/{companyId:guid}/transport-sheets")]
public class CompanyTransportSheetsGetController : ControllerBase
{
    private readonly IMediator _mediator;

    public CompanyTransportSheetsGetController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TransportSheetResponse>>> GetTransportSheets(Guid companyId)
    {
        var transportSheets = await _mediator.Send(new SearchAllTransportSheetsByCompanyQuery(companyId));
        return Ok(transportSheets);
    }
}
