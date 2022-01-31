using ValueOf;

namespace Rusell.Parcels.Domain;

public class ParcelCost : ValueOf<decimal, ParcelCost>
{
    public static implicit operator decimal(ParcelCost parcelCost) => parcelCost.Value;
    public static implicit operator ParcelCost(decimal parcelCost) => From(parcelCost);
}
