using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rusell.Addresses.Application;
using Rusell.Addresses.Application.Find;

namespace Rusell.Addresses.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/addresses/{id:guid}")]
public class AddressGetController : ControllerBase
{
    private readonly IMediator _mediator;

    public AddressGetController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<AddressResponse>> GetAddress(Guid id)
    {
        var address = await _mediator.Send(new FindAddressQuery(id.ToString()));
        if (address is null) return NotFound();

        return Ok(address);
    }
}
