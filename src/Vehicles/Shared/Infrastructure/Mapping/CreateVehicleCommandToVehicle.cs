using Mapster;
using Rusell.Vehicles.Application.Create;
using Rusell.Vehicles.Domain;

namespace Rusell.Vehicles.Shared.Infrastructure.Mapping;

public class CreateVehicleCommandToVehicle : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateVehicleCommand, Vehicle>()
            .MapWith(v => new VehicleBuilder()
                .WithLicensePlate(v.LicensePlate)
                .WithInternalNumber(v.InternalNumber)
                .WithPropertyCard(v.PropertyCard)
                .WithType(v.Type)
                .WithMark(v.Mark)
                .WithModel(v.Model)
                .WithModelNumber(v.ModelNumber)
                .WithColor(v.Color)
                .WithChairs(v.Chairs)
                .WithEngineNumber(v.EngineNumber)
                .WithChassisNumber(v.ChassisNumber)
                .WithOwnerId(v.OwnerId)
                .WithDriverId(v.DriverId)
                .WithCompanyId(v.CompanyId)
                .Build());
    }
}
