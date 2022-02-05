using Microsoft.EntityFrameworkCore;
using Rusell.Companies.Domain;
using Rusell.Shared.Domain.ValueObject;
using Rusell.Shared.Infrastructure.Repository;

namespace Rusell.Companies.Infrastructure.Persistence;

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

    public async Task<Company?> FindByNit(string nit)
    {
        return await Context.Set<Company>()
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Nit!.Value == nit);
    }

    public async Task<Company?> FindByUser(UserId userId)
    {
        return await Context.Set<Company>()
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.UserId == userId);
    }
}
