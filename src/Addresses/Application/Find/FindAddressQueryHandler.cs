using Mapster;
using Rusell.Shared.Domain.Bus.Query;

namespace Rusell.Addresses.Application.Find;

public class FindAddressQueryHandler : IQueryHandler<FindAddressQuery, AddressResponse>
{
  private readonly AddressFinder _finder;

  public FindAddressQueryHandler(AddressFinder finder)
  {
    _finder = finder;
  }

  public async Task<AddressResponse> Handle(FindAddressQuery request, CancellationToken cancellationToken)
  {
    var address = await _finder.Find(request.Id);
    return address.Adapt<AddressResponse>();
  }
}