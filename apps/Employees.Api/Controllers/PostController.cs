using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rusell.Employees.Api.Controllers.Requests;
using Rusell.Employees.Application.Create;

namespace Rusell.Employees.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/employees/companies/{companyId:guid}/employees")]
public class PostController : ControllerBase
{
    private readonly ILogger<PostController> _logger;
    private readonly IMediator _mediator;

    public PostController(ILogger<PostController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateEmployee(Guid companyId, [FromBody] CreateEmployeeRequest request)
    {
        try
        {
            var command = request.Adapt<CreateEmployeeCommand>();
            command.CompanyId = companyId;

            await _mediator.Send(command);
        }
        catch (DbUpdateException e)
        {
            _logger.LogError(e, "Error creating employee");
            return BadRequest();
        }

        return Ok();
    }
}
