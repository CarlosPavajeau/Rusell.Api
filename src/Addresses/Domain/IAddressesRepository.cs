using Rusell.Shared.Domain.Repository;

namespace Rusell.Addresses.Domain;

public interface IAddressesRepository : IRepository<Address, AddressId>
{
}