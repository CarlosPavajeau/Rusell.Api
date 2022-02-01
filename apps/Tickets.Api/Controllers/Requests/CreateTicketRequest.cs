namespace Rusell.Tickets.Api.Controllers.Requests;

public record CreateTicketRequest(decimal SeatPrice, uint Seats, string ClientId);
