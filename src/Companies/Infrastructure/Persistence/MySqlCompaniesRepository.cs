using Microsoft.EntityFrameworkCore;
using Rusell.Companies.Domain;
using Rusell.Shared.Infrastructure.Repository;

namespace Rusell.Companies.Infrastructure.Persistence;

public class MySqlCompaniesRepository : Repository<Company, CompanyId>, ICompaniesRepository
{
    public MySqlCompaniesRepository(DbContext context) : base(context)
    {
    }

    public override async Task<Company> Find(CompanyId key, bool noTracking)
    {
        var query = noTracking ? Context.Set<Company>().AsNoTracking() : Context.Set<Company>().AsTracking();

        return await query.FirstOrDefaultAsync(x => x.Id == key);
    }

    public async Task<Company?> FindByNit(string nit)
    {
        return await Context.Set<Company>()
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Nit!.Value == nit);
    }
}
