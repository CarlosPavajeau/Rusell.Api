using ValueOf;

namespace Rusell.Companies.Domain;

public class Nit : ValueOf<string, Nit>
{
    public static implicit operator string(Nit nit) => nit.Value;
    public static implicit operator Nit(string nit) => From(nit);
}