using ValueOf;

namespace Rusell.Tickets.Domain;

public class TicketSeats : ValueOf<uint, TicketSeats>
{
    public static implicit operator uint(TicketSeats ticketSeats) => ticketSeats.Value;
    public static implicit operator TicketSeats(uint ticketSeats) => From(ticketSeats);
}
