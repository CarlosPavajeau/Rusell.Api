using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Rusell.Shared.Infrastructure.Repository;
using Rusell.Tickets.Domain;

namespace Rusell.Tickets.Infrastructure.Persistence;

public class EntityFrameworkTicketsRepository : Repository<Ticket, TicketId>, ITicketsRepository
{
    public EntityFrameworkTicketsRepository(DbContext context) : base(context)
    {
    }

    public override async Task<Ticket?> Find(TicketId key, bool noTracking)
    {
        var query = noTracking ? Context.Set<Ticket>().AsNoTracking() : Context.Set<Ticket>().AsTracking();

        return await query
            .Include(x => x.Client)
            .FirstOrDefaultAsync(x => x.Id == key);
    }

    public override async Task<IEnumerable<Ticket>> SearchAll(Expression<Func<Ticket, bool>> predicate)
    {
        return await Context.Set<Ticket>()
            .AsNoTracking()
            .Include(x => x.Client)
            .Where(predicate)
            .ToListAsync();
    }
}
