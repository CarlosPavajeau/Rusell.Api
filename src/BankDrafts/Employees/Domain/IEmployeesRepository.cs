using Rusell.Shared.Domain.Repository;

namespace Rusell.BankDrafts.Employees.Domain;

public interface IEmployeesRepository : IRepository<Employee, EmployeeId>
{
}
