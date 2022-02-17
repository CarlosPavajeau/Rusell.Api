using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rusell.Companies.Application;
using Rusell.Companies.Application.FindByUser;

namespace Rusell.Companies.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/companies")]
public class CompanyByUserGetController : ControllerBase
{
    private readonly IMediator _mediator;

    public CompanyByUserGetController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<ActionResult<CompanyResponse>> GetCompanyByUser()
    {
        var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        if (userId is null)
            return Unauthorized();

        var company = await _mediator.Send(new FindCompanyByUserQuery(userId));
        if (company is null) return NotFound();

        return Ok(company);
    }
}
