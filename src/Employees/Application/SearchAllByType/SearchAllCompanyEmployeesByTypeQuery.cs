using Rusell.Employees.Domain;
using Rusell.Shared.Domain.Bus.Query;

namespace Rusell.Employees.Application.SearchAllByType;

public record SearchAllCompanyEmployeesByTypeQuery
    (Guid CompanyId, EmployeeType Type) : Query<IEnumerable<EmployeeResponse>>;
