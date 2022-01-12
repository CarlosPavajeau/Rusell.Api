using Rusell.Shared.Domain.Bus.Query;

namespace Rusell.Employees.Application.SearchAll;

public record SearchAllEmployeesQuery : Query<IEnumerable<EmployeeResponse>>;
