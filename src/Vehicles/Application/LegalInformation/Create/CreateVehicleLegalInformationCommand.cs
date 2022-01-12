using Rusell.Shared.Domain.Bus.Command;

namespace Rusell.Vehicles.Application.LegalInformation.Create;

public record CreateVehicleLegalInformationCommand(string Type, DateTime DueDate, DateTime RenovationDate,
    string LicensePlate) : Command
{
    public string LicensePlate { get; set; }
}
