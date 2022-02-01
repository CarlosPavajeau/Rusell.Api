using ValueOf;

namespace Rusell.Tickets.Domain;

public class TicketTotal : ValueOf<decimal, TicketTotal>
{
    public static implicit operator decimal(TicketTotal ticketTotal) => ticketTotal.Value;
    public static implicit operator TicketTotal(decimal ticketTotal) => From(ticketTotal);
}
