using Rusell.Parcels.Employees.Domain;

namespace Rusell.Parcels.Employees.Application.Create;

public class EmployeeCreator
{
    private readonly IEmployeesRepository _repository;

    public EmployeeCreator(IEmployeesRepository repository)
    {
        _repository = repository;
    }

    public async Task Create(EmployeeId id, EmployeeName fullName)
    {
        var employee = new Employee(id, fullName);
        await _repository.Save(employee);
    }
}
