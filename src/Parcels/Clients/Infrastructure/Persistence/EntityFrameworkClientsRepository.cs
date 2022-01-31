using Microsoft.EntityFrameworkCore;
using Rusell.Parcels.Clients.Domain;
using Rusell.Shared.Infrastructure.Repository;

namespace Rusell.Parcels.Clients.Infrastructure.Persistence;

public class EntityFrameworkClientsRepository : Repository<Client, ClientId>, IClientsRepository
{
    public EntityFrameworkClientsRepository(DbContext context) : base(context)
    {
    }

    public override async Task<Client?> Find(ClientId key, bool noTracking)
    {
        var query = noTracking ? Context.Set<Client>().AsNoTracking() : Context.Set<Client>().AsTracking();

        return await query.FirstOrDefaultAsync(x => x.Id == key);
    }
}
