using ValueOf;

namespace Rusell.Shared.Domain.ValueObject;

public class SecondSurname : ValueOf<string, SecondSurname>
{
    public static implicit operator string(SecondSurname secondSurname) => secondSurname.Value;
    public static implicit operator SecondSurname(string secondSurname) => From(secondSurname);
}
