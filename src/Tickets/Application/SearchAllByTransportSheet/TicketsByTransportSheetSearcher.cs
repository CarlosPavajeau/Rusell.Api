using Rusell.Tickets.Domain;

namespace Rusell.Tickets.Application.SearchAllByTransportSheet;

public class TicketsByTransportSheetSearcher
{
    private readonly ITicketsRepository _repository;

    public TicketsByTransportSheetSearcher(ITicketsRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Ticket>> SearchAllByTransportSheet(TransportSheetId transportSheetId)
    {
        return await _repository.SearchAll(x => x.TransportSheetId == transportSheetId);
    }
}
