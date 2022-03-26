using Mapster;
using Rusell.Shared.Domain.Bus.Query;

namespace Rusell.Parcels.Application.SearchAllBySender;

public class
    SearchAllParcelsBySenderQueryHandler : IQueryHandler<SearchAllParcelsBySenderQuery, IEnumerable<ParcelResponse>>
{
    private readonly ParcelsBySenderSearcher _searcher;

    public SearchAllParcelsBySenderQueryHandler(ParcelsBySenderSearcher searcher)
    {
        _searcher = searcher;
    }

    public async Task<IEnumerable<ParcelResponse>> Handle(SearchAllParcelsBySenderQuery request,
        CancellationToken cancellationToken)
    {
        var parcels = await _searcher.SearchAllBySender(request.SenderId);
        return parcels.Adapt<IEnumerable<ParcelResponse>>();
    }
}
