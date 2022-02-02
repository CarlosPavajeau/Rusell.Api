using Rusell.Shared.Domain.Bus.Query;

namespace Rusell.Tickets.Application.SearchAllByTransportSheet;

public record SearchAllTicketsByTransportSheetQuery(Guid TransportSheetId) : Query<IEnumerable<TicketResponse>>;
