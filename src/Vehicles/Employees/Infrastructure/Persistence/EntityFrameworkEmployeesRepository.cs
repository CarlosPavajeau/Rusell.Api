using Microsoft.EntityFrameworkCore;
using Rusell.Shared.Infrastructure.Repository;
using Rusell.Vehicles.Employees.Domain;

namespace Rusell.Vehicles.Employees.Infrastructure.Persistence;

public class EntityFrameworkEmployeesRepository : Repository<Employee, EmployeeId>, IEmployeesRepository
{
    public EntityFrameworkEmployeesRepository(DbContext context) : base(context)
    {
    }

    public override async Task<Employee?> Find(EmployeeId key, bool noTracking)
    {
        var query = noTracking ? Context.Set<Employee>().AsNoTracking() : Context.Set<Employee>().AsTracking();

        return await query.FirstOrDefaultAsync(e => e.Id == key);
    }
}
