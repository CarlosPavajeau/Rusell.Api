using Microsoft.EntityFrameworkCore;
using Rusell.Addresses.Domain;
using Rusell.Shared.Infrastructure.Repository;

namespace Rusell.Addresses.Infrastructure.Persistence;

public class MySqlAddressesRepository : Repository<Address, AddressId>, IAddressesRepository
{
    public MySqlAddressesRepository(DbContext context) : base(context)
    {
    }

    public override async Task<Address> Find(AddressId key, bool noTracking)
    {
        var query = noTracking ? Context.Set<Address>().AsNoTracking() : Context.Set<Address>().AsTracking();

        return await query.FirstOrDefaultAsync(a => a.Id == key);
    }
}
