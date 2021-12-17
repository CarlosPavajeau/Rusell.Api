using Microsoft.EntityFrameworkCore;
using Rusell.Routes.Addresses.Domain;
using Rusell.Shared.Infrastructure.Repository;

namespace Rusell.Routes.Addresses.Infrastructure.Persistence;

public class EntityFrameworkAddressesRepository : Repository<Address, AddressId>, IAddressesRepository
{
    public EntityFrameworkAddressesRepository(DbContext context) : base(context)
    {
    }

    public override Task<Address?> Find(AddressId key, bool noTracking)
    {
        var query = noTracking ? Context.Set<Address>().AsNoTracking() : Context.Set<Address>().AsTracking();

        return query.FirstOrDefaultAsync(x => x.Id == key);
    }
}
