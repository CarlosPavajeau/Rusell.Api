using Rusell.Shared.Domain.Bus.Query;

namespace Rusell.Vehicles.Employees.Application.CheckExists;

public class CheckEmployeeExistsQueryHandler : IQueryHandler<CheckEmployeeExistsQuery, bool>
{
    private readonly EmployeeExistsChecker _checker;

    public CheckEmployeeExistsQueryHandler(EmployeeExistsChecker checker)
    {
        _checker = checker;
    }

    public async Task<bool> Handle(CheckEmployeeExistsQuery request, CancellationToken cancellationToken) =>
        await _checker.CheckExists(request.Id);
}
