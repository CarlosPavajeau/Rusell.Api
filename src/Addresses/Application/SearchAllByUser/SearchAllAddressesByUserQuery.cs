using Rusell.Shared.Domain.Bus.Query;

namespace Rusell.Addresses.Application.SearchAllByUser;

public record SearchAllAddressesByUserQuery(string UserId) : Query<IEnumerable<AddressResponse>>;
