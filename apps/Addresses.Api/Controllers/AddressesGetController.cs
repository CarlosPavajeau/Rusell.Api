using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rusell.Addresses.Application;
using Rusell.Addresses.Application.SearchAllByUser;

namespace Rusell.Addresses.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/addresses")]
public class AddressesGetController : ControllerBase
{
    private readonly IMediator _mediator;

    public AddressesGetController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AddressResponse>>> GetAddresses()
    {
        var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        if (userId is null)
        {
            return Unauthorized();
        }

        var addresses = await _mediator.Send(new SearchAllAddressesByUserQuery(userId));
        return Ok(addresses);
    }
}
