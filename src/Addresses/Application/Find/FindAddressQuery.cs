using Rusell.Shared.Domain.Bus.Query;

namespace Rusell.Addresses.Application.Find;

public record FindAddressQuery(string Id) : Query<AddressResponse?>;