using Mapster;
using Rusell.Shared.Domain.Bus.Query;

namespace Rusell.Tickets.Application.SearchAllByClient;

public class
    SearchAllTicketsByClientQueryHandler : IQueryHandler<SearchAllTicketsByClientQuery, IEnumerable<TicketResponse>>
{
    private readonly TicketsByClientSearcher _searcher;

    public SearchAllTicketsByClientQueryHandler(TicketsByClientSearcher searcher)
    {
        _searcher = searcher;
    }

    public async Task<IEnumerable<TicketResponse>> Handle(SearchAllTicketsByClientQuery request,
        CancellationToken cancellationToken)
    {
        var tickets = await _searcher.SearchAllByClient(request.ClientId);
        return tickets.Adapt<IEnumerable<TicketResponse>>();
    }
}
