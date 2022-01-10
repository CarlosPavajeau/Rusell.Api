using ValueOf;

namespace Rusell.Vehicles.Domain;

public class InternalNumber : ValueOf<string, InternalNumber>
{
    public static implicit operator string(InternalNumber internalNumber) => internalNumber.Value;
    public static implicit operator InternalNumber(string internalNumber) => From(internalNumber);
}
