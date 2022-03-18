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
                    v.Id.ToString(),
                    v.Date,
                    v.DepartureTime == null ? null : v.DepartureTime.Value,
                    v.Quota,
                    v.VehicleLicensePlate,
                    v.RouteId.ToString(),
                    v.Dispatcher.FullName));
    }
}
