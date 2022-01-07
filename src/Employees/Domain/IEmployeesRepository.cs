using Rusell.Shared.Domain.Repository;

namespace Rusell.Employees.Domain;

public interface IEmployeesRepository : IRepository<Employee, EmployeeId>
{
    Task<IEnumerable<Employee>> SearchAllByCompany(CompanyId companyId);
}
