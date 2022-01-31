using ValueOf;

namespace Rusell.Parcels.Domain;

public class ParcelDescription : ValueOf<string, ParcelDescription>
{
    public static implicit operator string(ParcelDescription parcelDescription) => parcelDescription.Value;
    public static implicit operator ParcelDescription(string parcelDescription) => From(parcelDescription);
}
