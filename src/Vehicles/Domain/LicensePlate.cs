using ValueOf;

namespace Rusell.Vehicles.Domain;

public class LicensePlate : ValueOf<string, LicensePlate>
{
    public static implicit operator string(LicensePlate licensePlate) => licensePlate.Value;
    public static implicit operator LicensePlate(string licensePlate) => From(licensePlate);
}
