using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rusell.Companies.Application;
using Rusell.Companies.Application.FindByNit;

namespace Rusell.Companies.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/companies/by-nit/{nit}")]
public class CompanyByNitGetController : ControllerBase
{
    private readonly IMediator _mediator;

    public CompanyByNitGetController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<CompanyResponse>> GetCompanyByNit(string nit)
    {
        var company = await _mediator.Send(new FindCompanyByNitQuery(nit));
        if (company is null)
        {
            return NotFound();
        }

        return Ok(company);
    }
}
