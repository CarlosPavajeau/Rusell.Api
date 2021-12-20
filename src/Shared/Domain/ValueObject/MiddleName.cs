using ValueOf;

namespace Rusell.Shared.Domain.ValueObject;

public class MiddleName : ValueOf<string, MiddleName>
{
    public static implicit operator string(MiddleName middleName) => middleName.Value;
    public static implicit operator MiddleName(string middleName) => From(middleName);
}
