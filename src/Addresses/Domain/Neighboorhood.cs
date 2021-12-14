using ValueOf;

namespace Rusell.Addresses.Domain;

public class Neighborhood : ValueOf<string, Neighborhood>
{
    public static implicit operator string(Neighborhood neighborhood) => neighborhood.Value;
    public static implicit operator Neighborhood(string neighborhood) => From(neighborhood);
}