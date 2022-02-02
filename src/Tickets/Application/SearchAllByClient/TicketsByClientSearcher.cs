using Rusell.Tickets.Clients.Domain;
using Rusell.Tickets.Domain;

namespace Rusell.Tickets.Application.SearchAllByClient;

public class TicketsByClientSearcher
{
    private readonly ITicketsRepository _repository;

    public TicketsByClientSearcher(ITicketsRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Ticket>> SearchAllByClient(ClientId clientId)
    {
        return await _repository.SearchAll(x => x.ClientId == clientId);
    }
}
