using Rusell.Shared.Domain.Repository;

namespace Rusell.TransportSheets.Employees.Domain;

public interface IEmployeesRepository : IRepository<Employee, EmployeeId>
{
}
