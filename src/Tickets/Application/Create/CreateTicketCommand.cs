using Rusell.Shared.Domain.Bus.Command;

namespace Rusell.Tickets.Application.Create;

public record CreateTicketCommand(
    decimal SeatPrice,
    uint Seats,
    string ClientId,
    Guid TransportSheetId
) : Command<Guid>
{
    public Guid TransportSheetId { get; set; }
}
