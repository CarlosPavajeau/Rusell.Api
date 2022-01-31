using Microsoft.EntityFrameworkCore;
using Rusell.Parcels.Companies.Domain;
using Rusell.Shared.Infrastructure.Repository;

namespace Rusell.Parcels.Companies.Infrastructure.Persistence;

public class EntityFrameworkCompaniesRepository : Repository<Company, CompanyId>, ICompaniesRepository
{
    public EntityFrameworkCompaniesRepository(DbContext context) : base(context)
    {
    }

    public override async Task<Company?> Find(CompanyId key, bool noTracking)
    {
        var query = noTracking ? Context.Set<Company>().AsNoTracking() : Context.Set<Company>().AsTracking();

        return await query.FirstOrDefaultAsync(x => x.Id == key);
    }
}
