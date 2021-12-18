using Mapster;
using Rusell.Shared.Domain.Bus.Query;

namespace Rusell.Routes.Application.SearchAllByFromTo;

public class
    SearchAllRoutesByFromToQueryHandler : IQueryHandler<SearchAllRoutesByFromToQuery, IEnumerable<RouteResponse>>
{
    private readonly RoutesByFromToSearcher _searcher;

    public SearchAllRoutesByFromToQueryHandler(RoutesByFromToSearcher searcher)
    {
        _searcher = searcher;
    }

    public async Task<IEnumerable<RouteResponse>> Handle(SearchAllRoutesByFromToQuery request,
        CancellationToken cancellationToken)
    {
        var (from, to) = request;
        var routes = await _searcher.SearchAllByFromTo(from.Adapt<Addresses.Domain.Address>(),
            to.Adapt<Addresses.Domain.Address>());

        return routes.Adapt<IEnumerable<RouteResponse>>();
    }
}
