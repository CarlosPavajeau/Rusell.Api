using ValueOf;

namespace Rusell.Addresses.Domain;

public class StreetNumber : ValueOf<string, StreetNumber>
{
  public static implicit operator string(StreetNumber streetNumber) => streetNumber.Value;
  public static implicit operator StreetNumber(string streetNumber) => From(streetNumber);
}