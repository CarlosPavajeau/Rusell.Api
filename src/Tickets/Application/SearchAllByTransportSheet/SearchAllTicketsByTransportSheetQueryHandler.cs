using Mapster;
using Rusell.Shared.Domain.Bus.Query;
using Rusell.Tickets.Domain;

namespace Rusell.Tickets.Application.SearchAllByTransportSheet;

public class
    SearchAllTicketsByTransportSheetQueryHandler : IQueryHandler<SearchAllTicketsByTransportSheetQuery,
        IEnumerable<TicketResponse>>
{
    private readonly TicketsByTransportSheetSearcher _searcher;

    public SearchAllTicketsByTransportSheetQueryHandler(TicketsByTransportSheetSearcher searcher)
    {
        _searcher = searcher;
    }

    public async Task<IEnumerable<TicketResponse>> Handle(SearchAllTicketsByTransportSheetQuery request,
        CancellationToken cancellationToken)
    {
        var tickets = await _searcher.SearchAllByTransportSheet(TransportSheetId.From(request.TransportSheetId));
        return tickets.Adapt<IEnumerable<TicketResponse>>();
    }
}
