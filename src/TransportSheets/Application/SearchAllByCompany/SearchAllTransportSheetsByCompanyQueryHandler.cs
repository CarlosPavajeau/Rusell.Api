using Mapster;
using Rusell.Shared.Domain.Bus.Query;

namespace Rusell.TransportSheets.Application.SearchAllByCompany;

public class SearchAllTransportSheetsByCompanyQueryHandler : IQueryHandler<SearchAllTransportSheetsByCompanyQuery,
    IEnumerable<TransportSheetResponse>>
{
    private readonly TransportSheetsByCompanySearcher _searcher;

    public SearchAllTransportSheetsByCompanyQueryHandler(TransportSheetsByCompanySearcher searcher)
    {
        _searcher = searcher;
    }

    public async Task<IEnumerable<TransportSheetResponse>> Handle(SearchAllTransportSheetsByCompanyQuery request,
        CancellationToken cancellationToken)
    {
        var transportSheets = await _searcher.SearchAllByCompany(request.CompanyId);
        return transportSheets.Adapt<IEnumerable<TransportSheetResponse>>();
    }
}
