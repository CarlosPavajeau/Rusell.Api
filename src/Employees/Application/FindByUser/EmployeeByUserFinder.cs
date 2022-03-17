using Rusell.Employees.Domain;
using Rusell.Shared.Domain.ValueObject;

namespace Rusell.Employees.Application.FindByUser;

public class EmployeeByUserFinder
{
    private readonly IEmployeesRepository _repository;

    public EmployeeByUserFinder(IEmployeesRepository repository)
    {
        _repository = repository;
    }

    public async Task<Employee?> FindByUser(UserId userId)
    {
        var employee = await _repository.FindByUser(userId);
        return employee;
    }
}
