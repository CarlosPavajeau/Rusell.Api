using ValueOf;

namespace Rusell.Routes.Domain;

public class From : ValueOf<Guid, From>
{
    public static implicit operator Guid(From from) => from.Value;
    public static implicit operator From(Guid from) => From(from);
}
