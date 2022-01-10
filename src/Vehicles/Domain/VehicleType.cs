using ValueOf;

namespace Rusell.Vehicles.Domain;

public class VehicleType : ValueOf<string, VehicleType>
{
    public static implicit operator string(VehicleType vehicleType) => vehicleType.Value;
    public static implicit operator VehicleType(string vehicleType) => From(vehicleType);
}
