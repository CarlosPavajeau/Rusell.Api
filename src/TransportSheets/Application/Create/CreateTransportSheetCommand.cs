using Rusell.Shared.Domain.Bus.Command;

namespace Rusell.TransportSheets.Application.Create;

public record CreateTransportSheetCommand(
    uint Quota,
    string VehicleLicensePlate,
    string DispatcherId,
    Guid CompanyId) : Command<Guid>
{
    public Guid CompanyId { get; set; }
}
