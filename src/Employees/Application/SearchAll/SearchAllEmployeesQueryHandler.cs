using Mapster;
using Rusell.Shared.Domain.Bus.Query;

namespace Rusell.Employees.Application.SearchAll;

public class SearchAllEmployeesQueryHandler : IQueryHandler<SearchAllEmployeesQuery, IEnumerable<EmployeeResponse>>
{
    private readonly EmployeesSearcher _searcher;

    public SearchAllEmployeesQueryHandler(EmployeesSearcher searcher)
    {
        _searcher = searcher;
    }

    public async Task<IEnumerable<EmployeeResponse>> Handle(SearchAllEmployeesQuery request,
        CancellationToken cancellationToken)
    {
        var employees = await _searcher.SearchAll();
        return employees.Adapt<IEnumerable<EmployeeResponse>>();
    }
}
