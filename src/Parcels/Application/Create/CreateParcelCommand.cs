using Rusell.Shared.Domain.Bus.Command;

namespace Rusell.Parcels.Application.Create;

public record CreateParcelCommand(
    string Description,
    decimal Cost,
    string VehicleLicensePlate,
    string DispatcherId,
    string SenderId,
    string ReceiverId,
    Guid CompanyId) : Command
{
    public Guid CompanyId { get; set; }
}
