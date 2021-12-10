namespace Rusell.Addresses.Application;

public record AddressResponse(string Id, string State, string City, string Neighborhood, string StreetName,
    string Intersection, string StreetNumber, string Comments);
