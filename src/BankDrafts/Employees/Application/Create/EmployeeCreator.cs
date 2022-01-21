using Rusell.BankDrafts.Employees.Domain;

namespace Rusell.BankDrafts.Employees.Application.Create;

public class EmployeeCreator
{
    private readonly IEmployeesRepository _repository;

    public EmployeeCreator(IEmployeesRepository repository)
    {
        _repository = repository;
    }

    public async Task Create(EmployeeId id, EmployeeName name)
    {
        var employee = new Employee(id, name);
        await _repository.Save(employee);
    }
}
