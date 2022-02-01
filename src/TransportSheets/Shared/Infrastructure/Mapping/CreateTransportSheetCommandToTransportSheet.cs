using Mapster;
using Rusell.TransportSheets.Application.Create;
using Rusell.TransportSheets.Domain;

namespace Rusell.TransportSheets.Shared.Infrastructure.Mapping;

public class CreateTransportSheetCommandToTransportSheet : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateTransportSheetCommand, TransportSheet>()
            .MapWith(v => new TransportSheetBuilder()
                .WithId(Guid.NewGuid())
                .WithDate(DateTime.UtcNow)
                .WithQuota(v.Quota)
                .WithVehicleLicensePlate(v.VehicleLicensePlate)
                .WithDispatcherId(v.DispatcherId)
                .WithCompanyId(v.CompanyId)
                .Build());
    }
}
