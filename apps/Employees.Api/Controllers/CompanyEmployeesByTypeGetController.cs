using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rusell.Employees.Application;
using Rusell.Employees.Application.SearchAllByType;
using Rusell.Employees.Domain;

namespace Rusell.Employees.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/employees/companies/{companyId:guid}/employees/by-type")]
public class CompanyEmployeesByTypeGetController : ControllerBase
{
    private readonly IMediator _mediator;

    public CompanyEmployeesByTypeGetController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{employeeType}")]
    public async Task<ActionResult<IEnumerable<EmployeeResponse>>> GetEmployeesByType(Guid companyId,
        EmployeeType employeeType)
    {
        var result = await _mediator.Send(new SearchAllCompanyEmployeesByTypeQuery(companyId, employeeType));
        return Ok(result);
    }
}
