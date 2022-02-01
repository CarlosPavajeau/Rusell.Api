using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Rusell.Shared.Infrastructure.Repository;
using Rusell.TransportSheets.Domain;

namespace Rusell.TransportSheets.Infrastructure.Persistence;

public class EntityFrameworkTransportSheetsRepository : Repository<TransportSheet, TransportSheetId>,
    ITransportSheetsRepository
{
    public EntityFrameworkTransportSheetsRepository(DbContext context) : base(context)
    {
    }

    public override async Task<TransportSheet?> Find(TransportSheetId key, bool noTracking)
    {
        var query = noTracking
            ? Context.Set<TransportSheet>().AsNoTracking()
            : Context.Set<TransportSheet>().AsTracking();

        return await query
            .Include(x => x.Dispatcher)
            .FirstOrDefaultAsync(x => x.Id == key);
    }

    public override async Task<IEnumerable<TransportSheet>> SearchAll(Expression<Func<TransportSheet, bool>> predicate)
    {
        return await Context.Set<TransportSheet>()
            .AsNoTracking()
            .Include(x => x.Dispatcher)
            .Where(predicate)
            .ToListAsync();
    }
}
