using Mapster;
using Rusell.Shared.Domain.Bus.Query;

namespace Rusell.Parcels.Application.SearchAllByReceiverAndState;

public class
    SearchAllParcelsByReceiverAndStateQueryHandler : IQueryHandler<SearchAllParcelsByReceiverAndStateQuery,
        IEnumerable<ParcelResponse>>
{
    private readonly ParcelsByReceiverAndStateSearcher _searcher;

    public SearchAllParcelsByReceiverAndStateQueryHandler(ParcelsByReceiverAndStateSearcher searcher)
    {
        _searcher = searcher;
    }

    public async Task<IEnumerable<ParcelResponse>> Handle(SearchAllParcelsByReceiverAndStateQuery request,
        CancellationToken cancellationToken)
    {
        var (receiverId, parcelState) = request;
        var parcels = await _searcher.SearchAllByReceiverAndState(receiverId, parcelState);
        return parcels.Adapt<IEnumerable<ParcelResponse>>();
    }
}
