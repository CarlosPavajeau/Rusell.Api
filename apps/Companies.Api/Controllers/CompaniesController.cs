using System.Security.Claims;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rusell.Companies.Api.Controllers.Requests;
using Rusell.Companies.Application;
using Rusell.Companies.Application.Create;
using Rusell.Companies.Application.Find;
using Rusell.Companies.Application.FindByNit;

namespace Rusell.Companies.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class CompaniesController : ControllerBase
{
  private readonly ILogger<CompaniesController> _logger;
  private readonly IMediator _mediator;

  public CompaniesController(IMediator mediator, ILogger<CompaniesController> logger)
  {
    _mediator = mediator;
    _logger = logger;
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<CompanyResponse>> GetCompany(string id)
  {
    var company = await _mediator.Send(new FindCompanyQuery(id));
    if (company is null) return NotFound();

    return Ok(company);
  }

  [HttpGet("by_nit/{nit}")]
  public async Task<ActionResult<CompanyResponse>> GetCompanyByNit(string nit)
  {
    var company = await _mediator.Send(new FindCompanyByNitQuery(nit));
    if (company is null) return NotFound();

    return Ok(company);
  }

  [HttpPost]
  public async Task<IActionResult> CreateCompany([FromBody] CreateCompanyRequest request)
  {
    try
    {
      var commandUserId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
      if (commandUserId is null)
        return Unauthorized();

      var command = request.Adapt<CreateCompanyCommand>();
      command.UserId = commandUserId;
      await _mediator.Send(command);
    }
    catch (DbUpdateException e)
    {
      _logger.LogError(e, "Error creating company");
      return BadRequest();
    }

    return Ok();
  }
}