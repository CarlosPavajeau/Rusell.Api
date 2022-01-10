using Microsoft.EntityFrameworkCore;
using Rusell.Shared.Infrastructure.Repository;
using Rusell.Vehicles.Domain;

namespace Rusell.Vehicles.Infrastructure.Persistence;

public class EntityFrameworkVehiclesRepository : Repository<Vehicle, LicensePlate>, IVehiclesRepository
{
    public EntityFrameworkVehiclesRepository(DbContext context) : base(context)
    {
    }

    public override async Task<Vehicle?> Find(LicensePlate key, bool noTracking)
    {
        var query = noTracking ? Context.Set<Vehicle>().AsNoTracking() : Context.Set<Vehicle>().AsTracking();

        return await query
            .Include(x => x.Driver)
            .FirstOrDefaultAsync(x => x.LicensePlate == key);
    }
}
