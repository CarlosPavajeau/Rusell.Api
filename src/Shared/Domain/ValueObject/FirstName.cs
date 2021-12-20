using ValueOf;

namespace Rusell.Shared.Domain.ValueObject;

public class FirstName : ValueOf<string, FirstName>
{
    public static implicit operator string(FirstName firstName) => firstName.Value;
    public static implicit operator FirstName(string firstName) => From(firstName);
}
