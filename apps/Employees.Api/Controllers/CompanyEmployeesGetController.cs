using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rusell.Employees.Application;
using Rusell.Employees.Application.SearchAllByCompany;

namespace Rusell.Employees.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/employees/companies/{companyId:guid}/employees")]
public class CompanyEmployeesGetController : ControllerBase
{
    private readonly IMediator _mediator;

    public CompanyEmployeesGetController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EmployeeResponse>>> GetEmployees(Guid companyId)
    {
        var employees = await _mediator.Send(new SearchAllEmployeesByCompanyQuery(companyId));
        return Ok(employees);
    }
}
