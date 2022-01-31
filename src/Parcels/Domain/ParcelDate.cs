using ValueOf;

namespace Rusell.Parcels.Domain;

public class ParcelDate : ValueOf<DateTime, ParcelDate>
{
    public static implicit operator DateTime(ParcelDate parcelDate) => parcelDate.Value;
    public static implicit operator ParcelDate(DateTime parcelDate) => From(parcelDate);
}
