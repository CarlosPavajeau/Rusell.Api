using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rusell.Companies.Application;
using Rusell.Companies.Application.Find;

namespace Rusell.Companies.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/companies/{id}")]
public class CompanyGetController : ControllerBase
{
    private readonly IMediator _mediator;

    public CompanyGetController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<CompanyResponse>> GetCompany(string id)
    {
        var company = await _mediator.Send(new FindCompanyQuery(id));
        if (company is null) return NotFound();

        return Ok(company);
    }
}
