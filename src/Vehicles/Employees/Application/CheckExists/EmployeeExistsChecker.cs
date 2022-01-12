using Rusell.Vehicles.Employees.Domain;

namespace Rusell.Vehicles.Employees.Application.CheckExists;

public class EmployeeExistsChecker
{
    private readonly IEmployeesRepository _repository;

    public EmployeeExistsChecker(IEmployeesRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> CheckExists(EmployeeId id)
    {
        return await _repository.Any(x => x.Id == id);
    }
}
