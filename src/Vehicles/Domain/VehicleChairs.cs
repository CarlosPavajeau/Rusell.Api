using ValueOf;

namespace Rusell.Vehicles.Domain;

public class VehicleChairs : ValueOf<int, VehicleChairs>
{
    public static implicit operator int(VehicleChairs vehicleChairs) => vehicleChairs.Value;
    public static implicit operator VehicleChairs(int vehicleChairs) => From(vehicleChairs);
}
