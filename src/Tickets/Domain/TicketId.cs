using ValueOf;

namespace Rusell.Tickets.Domain;

public class TicketId : ValueOf<Guid, TicketId>
{
    public static implicit operator Guid(TicketId ticketId) => ticketId.Value;
    public static implicit operator TicketId(Guid ticketId) => From(ticketId);
}
