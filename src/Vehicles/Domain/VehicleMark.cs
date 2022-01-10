using ValueOf;

namespace Rusell.Vehicles.Domain;

public class VehicleMark : ValueOf<string, VehicleMark>
{
    public static implicit operator string(VehicleMark vehicleMark) => vehicleMark.Value;
    public static implicit operator VehicleMark(string vehicleMark) => From(vehicleMark);
}
