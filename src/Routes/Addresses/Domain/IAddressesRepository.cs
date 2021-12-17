using Rusell.Shared.Domain.Repository;

namespace Rusell.Routes.Addresses.Domain;

public interface IAddressesRepository : IRepository<Address, AddressId>
{
}
