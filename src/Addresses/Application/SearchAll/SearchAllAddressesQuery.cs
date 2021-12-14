using Rusell.Shared.Domain.Bus.Query;

namespace Rusell.Addresses.Application.SearchAll;

public record SearchAllAddressesQuery : Query<IEnumerable<AddressResponse>>;