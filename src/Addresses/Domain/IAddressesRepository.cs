using Rusell.Shared.Domain.Repository;
using Rusell.Shared.Domain.ValueObject;

namespace Rusell.Addresses.Domain;

public interface IAddressesRepository : IRepository<Address, AddressId>
{
    public Task<IEnumerable<Address>> SearchAllByUser(UserId userId);
}