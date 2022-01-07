using Mapster;
using Rusell.Shared.Domain.Bus.Query;

namespace Rusell.Employees.Application.SearchAllByCompany;

public class
    SearchAllEmployeesByCompanyQueryHandler : IQueryHandler<SearchAllEmployeesByCompanyQuery,
        IEnumerable<EmployeeResponse>>
{
    private readonly EmployeesByCompanySearcher _searcher;

    public SearchAllEmployeesByCompanyQueryHandler(EmployeesByCompanySearcher searcher)
    {
        _searcher = searcher;
    }

    public async Task<IEnumerable<EmployeeResponse>> Handle(SearchAllEmployeesByCompanyQuery request,
        CancellationToken cancellationToken)
    {
        var employees = await _searcher.SearchAllByCompany(request.CompanyId);
        return employees.Adapt<IEnumerable<EmployeeResponse>>();
    }
}
