using Mapster;
using Rusell.TransportSheets.Application;
using Rusell.TransportSheets.Domain;

namespace Rusell.TransportSheets.Shared.Infrastructure.Mapping;

public class TransportSheetToTransportSheetResponse : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<TransportSheet, TransportSheetResponse>()
            .MapWith(v =>
                new TransportSheetResponse(
                    v.Date,
                    v.DepartureTime,
                    v.Quota,
                    v.VehicleLicensePlate,
                    v.Dispatcher.FullName));
    }
}
