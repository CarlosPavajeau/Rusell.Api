using ValueOf;

namespace Rusell.Addresses.Domain;

public class StreetName : ValueOf<string, StreetName>
{
  public static implicit operator string(StreetName streetName) => streetName.Value;
  public static implicit operator StreetName(string streetName) => From(streetName);
}