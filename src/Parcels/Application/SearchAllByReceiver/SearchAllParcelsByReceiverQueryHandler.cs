using Mapster;
using Rusell.Shared.Domain.Bus.Query;

namespace Rusell.Parcels.Application.SearchAllByReceiver;

public class
    SearchAllParcelsByReceiverQueryHandler : IQueryHandler<SearchAllParcelsByReceiverQuery, IEnumerable<ParcelResponse>>
{
    private readonly ParcelsByReceiverSearcher _searcher;

    public SearchAllParcelsByReceiverQueryHandler(ParcelsByReceiverSearcher searcher)
    {
        _searcher = searcher;
    }

    public async Task<IEnumerable<ParcelResponse>> Handle(SearchAllParcelsByReceiverQuery request,
        CancellationToken cancellationToken)
    {
        var parcels = await _searcher.SearchAllByReceiver(request.ReceiverId);
        return parcels.Adapt<IEnumerable<ParcelResponse>>();
    }
}
