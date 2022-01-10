using ValueOf;

namespace Rusell.Vehicles.Domain;

public class ChassisNumber : ValueOf<string, ChassisNumber>
{
    public static implicit operator string(ChassisNumber chassisNumber) => chassisNumber.Value;
    public static implicit operator ChassisNumber(string chassisNumber) => From(chassisNumber);
}
