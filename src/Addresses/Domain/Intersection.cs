using ValueOf;

namespace Rusell.Addresses.Domain;

public class Intersection : ValueOf<string, Intersection>
{
  public static implicit operator string(Intersection intersection) => intersection.Value;
  public static implicit operator Intersection(string intersection) => From(intersection);
}