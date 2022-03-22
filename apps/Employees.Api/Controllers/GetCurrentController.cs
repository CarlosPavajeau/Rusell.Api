using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rusell.Employees.Application;
using Rusell.Employees.Application.FindByUser;

namespace Rusell.Employees.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/employees/current")]
public class GetCurrentController : ControllerBase
{
    private readonly IMediator _mediator;

    public GetCurrentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<EmployeeResponse>> GetEmployeeByUser()
    {
        var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

        if (userId is null)
        {
            return Unauthorized();
        }

        var employee = await _mediator.Send(new FindEmployeeByUserQuery(userId));

        if (employee is null)
        {
            return NotFound();
        }

        return Ok(employee);
    }
}
