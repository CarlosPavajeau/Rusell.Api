using Mapster;
using Rusell.Parcels.Application.Create;
using Rusell.Parcels.Domain;

namespace Rusell.Parcels.Shared.Infrastructure.Mapping;

public class CreateParcelCommandToParcel : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateParcelCommand, Parcel>()
            .MapWith(v => new ParcelBuilder()
                .WithId(Guid.NewGuid())
                .WithDate(DateTime.UtcNow)
                .WithCost(v.Cost)
                .WithDescription(v.Description)
                .WithState(ParcelState.Created)
                .WithVehicleLicensePlate(v.VehicleLicensePlate)
                .WithDispatcherId(v.DispatcherId)
                .WithSenderId(v.SenderId)
                .WithReceiverId(v.ReceiverId)
                .WithCompanyId(v.CompanyId)
                .Build());
    }
}
