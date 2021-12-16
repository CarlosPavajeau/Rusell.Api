using ValueOf;

namespace Rusell.Routes.Domain;

public class Cost : ValueOf<decimal, Cost>
{
    public static implicit operator decimal(Cost cost) => cost.Value;
    public static implicit operator Cost(decimal cost) => From(cost);
}
