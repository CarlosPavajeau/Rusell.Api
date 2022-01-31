using Rusell.Shared.Domain.Repository;

namespace Rusell.Parcels.Employees.Domain;

public interface IEmployeesRepository : IRepository<Employee, EmployeeId>
{
}
