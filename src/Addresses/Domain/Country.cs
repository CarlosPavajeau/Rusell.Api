using ValueOf;

namespace Rusell.Addresses.Domain;

public class Country : ValueOf<string, Country>
{
    public static implicit operator string(Country country) => country.Value;
    public static implicit operator Country(string country) => From(country);
}