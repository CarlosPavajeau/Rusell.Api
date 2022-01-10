using Rusell.Shared.Domain.Repository;

namespace Rusell.Vehicles.Employees.Domain;

public interface IEmployeesRepository : IRepository<Employee, EmployeeId>
{
}
