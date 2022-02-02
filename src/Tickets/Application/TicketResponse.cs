using Rusell.Tickets.Domain;

namespace Rusell.Tickets.Application;

public record TicketResponse(
    Guid Id,
    DateTime Date,
    TicketState State,
    decimal SeatPrice,
    uint Seats,
    decimal Total,
    string ClientName);
