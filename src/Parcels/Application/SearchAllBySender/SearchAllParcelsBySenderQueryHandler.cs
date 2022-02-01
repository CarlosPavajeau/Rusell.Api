using Mapster;
using Rusell.Parcels.Application.SearchAllByReceiver;
using Rusell.Shared.Domain.Bus.Query;

namespace Rusell.Parcels.Application.SearchAllBySender;

public class
    SearchAllParcelsBySenderQueryHandler : IQueryHandler<SearchAllParcelsByReceiverQuery, IEnumerable<ParcelResponse>>
{
    private readonly ParcelsBySenderSearcher _searcher;

    public SearchAllParcelsBySenderQueryHandler(ParcelsBySenderSearcher searcher)
    {
        _searcher = searcher;
    }

    public async Task<IEnumerable<ParcelResponse>> Handle(SearchAllParcelsByReceiverQuery request,
        CancellationToken cancellationToken)
    {
        var parcels = await _searcher.SearchAllBySender(request.ReceiverId);
        return parcels.Adapt<IEnumerable<ParcelResponse>>();
    }
}
