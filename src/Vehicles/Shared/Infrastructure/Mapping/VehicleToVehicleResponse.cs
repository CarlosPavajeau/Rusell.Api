using Mapster;
using Rusell.Vehicles.Application;
using Rusell.Vehicles.Domain;

namespace Rusell.Vehicles.Shared.Infrastructure.Mapping;

public class VehicleToVehicleResponse : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Vehicle, VehicleResponse>()
            .Map(x => x.DriverName, x => x.Driver.FullName);
    }
}
