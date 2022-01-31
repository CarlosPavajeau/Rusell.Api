using ValueOf;

namespace Rusell.Parcels.Domain;

public class ParcelId : ValueOf<Guid, ParcelId>
{
    public static implicit operator Guid(ParcelId parcelId) => parcelId.Value;
    public static implicit operator ParcelId(Guid parcelId) => From(parcelId);
}
