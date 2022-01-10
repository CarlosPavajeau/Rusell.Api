using ValueOf;

namespace Rusell.Vehicles.Domain;

public class VehicleColor : ValueOf<string, VehicleColor>
{
    public static implicit operator string(VehicleColor vehicleColor) => vehicleColor.Value;
    public static implicit operator VehicleColor(string vehicleColor) => From(vehicleColor);
}
