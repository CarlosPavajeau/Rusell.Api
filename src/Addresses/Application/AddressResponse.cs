namespace Rusell.Addresses.Application;

public record AddressResponse(string Id, string Country, string State, string City, string Neighborhood,
  string StreetName, string Intersection, string StreetNumber, string Comments);