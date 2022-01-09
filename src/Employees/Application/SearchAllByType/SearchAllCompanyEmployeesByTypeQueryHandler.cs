using Mapster;
using Rusell.Shared.Domain.Bus.Query;

namespace Rusell.Employees.Application.SearchAllByType;

public class
    SearchAllCompanyEmployeesByTypeQueryHandler : IQueryHandler<SearchAllCompanyEmployeesByTypeQuery,
        IEnumerable<EmployeeResponse>>
{
    private readonly CompanyEmployeesByTypeSearcher _searcher;

    public SearchAllCompanyEmployeesByTypeQueryHandler(CompanyEmployeesByTypeSearcher searcher)
    {
        _searcher = searcher;
    }

    public async Task<IEnumerable<EmployeeResponse>> Handle(SearchAllCompanyEmployeesByTypeQuery request,
        CancellationToken cancellationToken)
    {
        var (companyId, employeeType) = request;
        var employees = await _searcher.SearchAllByType(companyId, employeeType);

        return employees.Adapt<IEnumerable<EmployeeResponse>>();
    }
}
