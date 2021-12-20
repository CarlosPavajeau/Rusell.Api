using ValueOf;

namespace Rusell.Shared.Domain.ValueObject;

public class FirstSurname : ValueOf<string, FirstSurname>
{
    public static implicit operator string(FirstSurname firstSurname) => firstSurname.Value;
    public static implicit operator FirstSurname(string firstSurname) => From(firstSurname);
}
