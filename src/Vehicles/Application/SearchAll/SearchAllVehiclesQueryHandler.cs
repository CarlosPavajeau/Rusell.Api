using Mapster;
using Rusell.Shared.Domain.Bus.Query;

namespace Rusell.Vehicles.Application.SearchAll;

public class SearchAllVehiclesQueryHandler : IQueryHandler<SearchAllVehiclesQuery, IEnumerable<VehicleResponse>>
{
    private readonly VehiclesSearcher _searcher;

    public SearchAllVehiclesQueryHandler(VehiclesSearcher searcher)
    {
        _searcher = searcher;
    }

    public async Task<IEnumerable<VehicleResponse>> Handle(SearchAllVehiclesQuery request,
        CancellationToken cancellationToken)
    {
        var vehicles = await _searcher.SearchAll(request.CompanyId);
        return vehicles.Adapt<IEnumerable<VehicleResponse>>();
    }
}
