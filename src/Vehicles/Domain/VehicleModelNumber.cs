using ValueOf;

namespace Rusell.Vehicles.Domain;

public class VehicleModelNumber : ValueOf<string, VehicleModelNumber>
{
    public static implicit operator string(VehicleModelNumber vehicleModelNumber) => vehicleModelNumber.Value;
    public static implicit operator VehicleModelNumber(string vehicleModelNumber) => From(vehicleModelNumber);
}
