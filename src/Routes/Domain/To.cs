using ValueOf;

namespace Rusell.Routes.Domain;

public class To : ValueOf<Guid, To>
{
    public static implicit operator Guid(To to) => to.Value;
    public static implicit operator To(Guid to) => From(to);
}
