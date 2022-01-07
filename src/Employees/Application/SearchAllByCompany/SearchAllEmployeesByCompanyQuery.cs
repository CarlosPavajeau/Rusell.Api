using Rusell.Shared.Domain.Bus.Query;

namespace Rusell.Employees.Application.SearchAllByCompany;

public record SearchAllEmployeesByCompanyQuery(Guid CompanyId) : Query<IEnumerable<EmployeeResponse>>;
