using ValueOf;

namespace Rusell.Vehicles.Domain;

public class VehicleModel : ValueOf<string, VehicleModel>
{
    public static implicit operator string(VehicleModel vehicleModel) => vehicleModel.Value;
    public static implicit operator VehicleModel(string vehicleModel) => From(vehicleModel);
}
