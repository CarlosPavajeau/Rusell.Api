using Mapster;
using Rusell.Shared.Domain.Bus.Query;

namespace Rusell.Routes.Application.SearchAllByCompany;

public class
    SearchAllRoutesByCompanyQueryHandler : IQueryHandler<SearchAllRoutesByCompanyQuery, IEnumerable<RouteResponse>>
{
    private readonly RoutesByCompanySearcher _searcher;

    public SearchAllRoutesByCompanyQueryHandler(RoutesByCompanySearcher searcher)
    {
        _searcher = searcher;
    }

    public async Task<IEnumerable<RouteResponse>> Handle(SearchAllRoutesByCompanyQuery request,
        CancellationToken cancellationToken)
    {
        var companies = await _searcher.SearchAllByCompany(request.CompanyId);

        return companies.Adapt<IEnumerable<RouteResponse>>();
    }
}
