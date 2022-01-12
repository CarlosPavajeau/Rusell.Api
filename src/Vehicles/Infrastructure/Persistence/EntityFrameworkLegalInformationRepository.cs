using Microsoft.EntityFrameworkCore;
using Rusell.Shared.Infrastructure.Repository;
using Rusell.Vehicles.Domain.LegalInformation;

namespace Rusell.Vehicles.Infrastructure.Persistence;

public class EntityFrameworkLegalInformationRepository : Repository<VehicleLegalInformation, LegalInformationId>,
    ILegalInformationRepository
{
    public EntityFrameworkLegalInformationRepository(DbContext context) : base(context)
    {
    }

    public override async Task<VehicleLegalInformation?> Find(LegalInformationId key, bool noTracking)
    {
        var query = noTracking
            ? Context.Set<VehicleLegalInformation>().AsNoTracking()
            : Context.Set<VehicleLegalInformation>().AsTracking();

        return await query.FirstOrDefaultAsync(x => x.Id == key);
    }
}
