using Rusell.Vehicles.Employees.Domain;

namespace Rusell.Vehicles.Employees.Application.Create;

public class EmployeeCreator
{
    private readonly IEmployeesRepository _repository;

    public EmployeeCreator(IEmployeesRepository repository)
    {
        _repository = repository;
    }

    public async Task Create(string id, string fullName)
    {
        var employee = new Employee(id, fullName);
        await _repository.Save(employee);
    }
}
