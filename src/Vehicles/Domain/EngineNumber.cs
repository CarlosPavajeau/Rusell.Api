using ValueOf;

namespace Rusell.Vehicles.Domain;

public class EngineNumber : ValueOf<string, EngineNumber>
{
    public static implicit operator string(EngineNumber engineNumber) => engineNumber.Value;
    public static implicit operator EngineNumber(string engineNumber) => From(engineNumber);
}
