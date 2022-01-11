using Rusell.Shared.Domain.Bus.Command;

namespace Rusell.Vehicles.Application.Create;

public record CreateVehicleCommand(
    string LicensePlate,
    string InternalNumber,
    string PropertyCard,
    string Type,
    string Mark,
    string Model,
    string ModelNumber,
    string Color,
    int Chairs,
    string EngineNumber,
    string ChassisNumber,
    string OwnerId,
    string DriverId,
    Guid CompanyId) : Command
{
    public Guid CompanyId { get; set; }
}
