using Mapster;
using Rusell.Shared.Domain.Bus.Query;

namespace Rusell.Employees.Application.FindByUser;

public class FindEmployeeByUserQueryHandler : IQueryHandler<FindEmployeeByUserQuery, EmployeeResponse?>
{
    private readonly EmployeeByUserFinder _finder;

    public FindEmployeeByUserQueryHandler(EmployeeByUserFinder finder)
    {
        _finder = finder;
    }

    public async Task<EmployeeResponse?> Handle(FindEmployeeByUserQuery request, CancellationToken cancellationToken)
    {
        var employee = await _finder.FindByUser(request.UserId);
        return employee?.Adapt<EmployeeResponse>();
    }
}
