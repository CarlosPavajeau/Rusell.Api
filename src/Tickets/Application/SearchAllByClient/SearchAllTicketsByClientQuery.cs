using Rusell.Shared.Domain.Bus.Query;

namespace Rusell.Tickets.Application.SearchAllByClient;

public record SearchAllTicketsByClientQuery(string ClientId) : Query<IEnumerable<TicketResponse>>;
