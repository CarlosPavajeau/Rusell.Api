using Rusell.Shared.Domain.Bus.Command;

namespace Rusell.Addresses.Application.Create;

public record CreateAddressCommand(string Country, string State, string City, string Neighborhood, string StreetName,
    string Intersection, string StreetNumber, string Comments, string UserId) : Command
{
    public string UserId { get; set; }
}