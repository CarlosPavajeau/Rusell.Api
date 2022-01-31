using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Rusell.Parcels.Domain;
using Rusell.Shared.Infrastructure.Repository;

namespace Rusell.Parcels.Infrastructure.Persistence;

public class EntityFrameworkParcelsRepository : Repository<Parcel, ParcelId>, IParcelsRepository
{
    public EntityFrameworkParcelsRepository(DbContext context) : base(context)
    {
    }

    public override async Task<Parcel?> Find(ParcelId key, bool noTracking)
    {
        var query = noTracking ? Context.Set<Parcel>().AsNoTracking() : Context.Set<Parcel>().AsTracking();

        return await query
            .Include(x => x.Dispatcher)
            .Include(x => x.Sender)
            .Include(x => x.Receiver)
            .Include(x => x.Company)
            .FirstOrDefaultAsync(x => x.Id == key);
    }

    public override async Task<IEnumerable<Parcel>> SearchAll(Expression<Func<Parcel, bool>> predicate)
    {
        return await Context.Set<Parcel>()
            .AsNoTracking()
            .Include(x => x.Dispatcher)
            .Include(x => x.Sender)
            .Include(x => x.Receiver)
            .Include(x => x.Company)
            .Where(predicate)
            .ToListAsync();
    }
}
