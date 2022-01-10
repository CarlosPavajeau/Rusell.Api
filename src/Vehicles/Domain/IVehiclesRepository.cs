using Rusell.Shared.Domain.Repository;

namespace Rusell.Vehicles.Domain;

public interface IVehiclesRepository : IRepository<Vehicle, LicensePlate>
{
}
