using Rusell.Shared.Domain.Bus.Query;

namespace Rusell.Employees.Application.FindByUser;

public record FindEmployeeByUserQuery(string UserId) : Query<EmployeeResponse?>;
