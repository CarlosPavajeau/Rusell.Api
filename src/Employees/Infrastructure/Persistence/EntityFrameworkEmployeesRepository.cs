using Microsoft.EntityFrameworkCore;
using Rusell.Employees.Domain;
using Rusell.Shared.Infrastructure.Repository;

namespace Rusell.Employees.Infrastructure.Persistence;

public class EntityFrameworkEmployeesRepository : Repository<Employee, EmployeeId>, IEmployeesRepository
{
    public EntityFrameworkEmployeesRepository(DbContext context) : base(context)
    {
    }

    public override async Task<Employee?> Find(EmployeeId key, bool noTracking)
    {
        var query = noTracking ? Context.Set<Employee>().AsNoTracking() : Context.Set<Employee>().AsTracking();

        return await query.FirstOrDefaultAsync(x => x.Id == key);
    }

    public async Task<IEnumerable<Employee>> SearchAllByCompany(CompanyId companyId)
    {
        return await Context.Set<Employee>()
            .AsNoTracking()
            .Where(e => e.CompanyId == companyId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Employee>> SearchAllByType(CompanyId companyId, EmployeeType type)
    {
        return await Context.Set<Employee>()
            .AsNoTracking()
            .Where(e => e.CompanyId == companyId && e.Type == type)
            .ToListAsync();
    }
}
