using Microsoft.EntityFrameworkCore;
using Rusell.Shared.Infrastructure.Repository;
using Rusell.Tickets.Clients.Domain;

namespace Rusell.Tickets.Clients.Infrastructure.Persistence;

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
