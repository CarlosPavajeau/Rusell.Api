using ValueOf;

namespace Rusell.Tickets.Domain;

public class TicketSeatPrice : ValueOf<decimal, TicketSeatPrice>
{
    public static implicit operator decimal(TicketSeatPrice ticketSeatPrice) => ticketSeatPrice.Value;
    public static implicit operator TicketSeatPrice(decimal ticketSeatPrice) => From(ticketSeatPrice);
}
