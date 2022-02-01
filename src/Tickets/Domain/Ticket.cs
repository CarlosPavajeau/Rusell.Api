using Rusell.Shared.Domain.Aggregate;
using Rusell.Tickets.Clients.Domain;

namespace Rusell.Tickets.Domain;

public class Ticket : AggregateRoot
{
    internal Ticket()
    {
        // required by EF
    }

    public TicketId Id { get; set; }
    public TicketDate Date { get; set; }
    public TicketState State { get; set; }
    public TicketSeatPrice SeatPrice { get; set; }
    public TicketSeats Seats { get; set; }
    public TicketTotal Total { get; set; }

    public ClientId ClientId { get; set; }
    public Client Client { get; set; }

    public TransportSheetId TransportSheetId { get; set; }
}
