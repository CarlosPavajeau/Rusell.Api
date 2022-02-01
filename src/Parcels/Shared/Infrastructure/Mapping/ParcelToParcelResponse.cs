using Mapster;
using Rusell.Parcels.Application;
using Rusell.Parcels.Domain;

namespace Rusell.Parcels.Shared.Infrastructure.Mapping;

public class ParcelToParcelResponse : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Parcel, ParcelResponse>()
            .MapWith(v => new ParcelResponse(
                v.Date,
                v.Description,
                v.Cost,
                v.State,
                v.VehicleLicensePlate,
                v.Dispatcher.FullName,
                v.Sender.FullName,
                v.Receiver.FullName,
                v.Company.Name));
    }
}
