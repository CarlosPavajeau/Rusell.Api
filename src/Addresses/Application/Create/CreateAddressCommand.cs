using Rusell.Shared.Domain.Bus.Command;

namespace Rusell.Addresses.Application.Create;

public record CreateAddressCommand(string State, string City, string Neighborhood, string StreetName,
    string Intersection, string StreetNumber, string Comments) : Command;