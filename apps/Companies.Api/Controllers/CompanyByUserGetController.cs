using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rusell.Companies.Application;
using Rusell.Companies.Application.FindByUser;

namespace Rusell.Companies.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/companies/by-user/{userId}")]
public class CompanyByUserGetController : ControllerBase
{
    private readonly IMediator _mediator;

    public CompanyByUserGetController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<ActionResult<CompanyResponse>> GetCompanyByUser(string userId)
    {
        var company = await _mediator.Send(new FindCompanyByUserQuery(userId));
        if (company is null) return NotFound();

        return Ok(company);
    }
}
