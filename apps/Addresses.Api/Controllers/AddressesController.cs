using System.Security.Claims;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rusell.Addresses.Api.Controllers.Requests;
using Rusell.Addresses.Application;
using Rusell.Addresses.Application.Create;
using Rusell.Addresses.Application.Find;
using Rusell.Addresses.Application.SearchAll;

namespace Rusell.Addresses.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class AddressesController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<AddressesController> _logger;

    public AddressesController(IMediator mediator, ILogger<AddressesController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AddressResponse>>> GetAddresses()
    {
        var addresses = await _mediator.Send(new SearchAllAddressesQuery());
        return Ok(addresses);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AddressResponse>> GetAddress(string id)
    {
        var address = await _mediator.Send(new FindAddressQuery(id));
        if (address is null)
        {
            return NotFound();
        }

        return Ok(address);
    }

    [HttpPost]
    public async Task<ActionResult> SaveAddress([FromBody] CreateAddressRequest request)
    {
        try
        {
            var command = request.Adapt<CreateAddressCommand>();
            await _mediator.Send(command);
        }
        catch (DbUpdateException e)
        {
            _logger.LogError(e, "Error saving address");
            return BadRequest();
        }

        return Ok();
    }
}
