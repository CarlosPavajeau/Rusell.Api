using Rusell.Employees.Domain;

namespace Rusell.Employees.Application.SearchAll;

public class EmployeesSearcher
{
    private readonly IEmployeesRepository _repository;

    public EmployeesSearcher(IEmployeesRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Employee>> SearchAll() => await _repository.SearchAll();
}
