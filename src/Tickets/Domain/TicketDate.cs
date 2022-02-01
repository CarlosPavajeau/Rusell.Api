using ValueOf;

namespace Rusell.Tickets.Domain;

public class TicketDate : ValueOf<DateTime, TicketDate>
{
    public static implicit operator DateTime(TicketDate ticketDate) => ticketDate.Value;
    public static implicit operator TicketDate(DateTime ticketDate) => From(ticketDate);
}
