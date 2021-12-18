using Microsoft.EntityFrameworkCore;
using Rusell.Routes.Addresses.Domain;
using Rusell.Routes.Companies.Domain;
using Rusell.Routes.Domain;
using Rusell.Shared.Infrastructure.Repository;

namespace Rusell.Routes.Infrastructure.Persistence;

public class EntityFrameworkRoutesRepository : Repository<Route, RouteId>, IRoutesRepository
{
    public EntityFrameworkRoutesRepository(DbContext context) : base(context)
    {
    }

    public override async Task<Route?> Find(RouteId key, bool noTracking)
    {
        var query = noTracking ? Context.Set<Route>().AsNoTracking() : Context.Set<Route>().AsTracking();

        return await query.FirstOrDefaultAsync(x => x.Id == key);
    }

    public async Task<IEnumerable<Route>> SearchAllByCompany(CompanyId companyId)
    {
        return await Context.Set<Route>()
            .AsNoTracking()
            .Where(r => r.CompanyId == companyId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Route>> SearchAllByFromTo(Address from, Address to)
    {
        return await Context.Set<Route>()
            .AsNoTracking()
            .Include(x => x.From)
            .Include(x => x.To)
            .Where(x =>
                x.From.Country.Value == from.Country.Value &&
                x.From.State.Value == from.State.Value &&
                x.From.City.Value == from.City.Value &&
                x.To.Country.Value == to.Country.Value &&
                x.To.State.Value == to.State.Value &&
                x.To.City.Value == to.City.Value)
            .ToListAsync();
    }
}
