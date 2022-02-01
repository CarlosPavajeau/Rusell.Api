using Rusell.Shared.Domain.Repository;

namespace Rusell.Tickets.Domain;

public interface ITicketsRepository : IRepository<Ticket, TicketId>
{
}
