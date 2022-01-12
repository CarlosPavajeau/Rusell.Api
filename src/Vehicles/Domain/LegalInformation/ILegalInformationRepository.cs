using Rusell.Shared.Domain.Repository;

namespace Rusell.Vehicles.Domain.LegalInformation;

public interface ILegalInformationRepository : IRepository<VehicleLegalInformation, LegalInformationId>
{
}
