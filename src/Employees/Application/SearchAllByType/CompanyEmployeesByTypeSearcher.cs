using Rusell.Employees.Domain;

namespace Rusell.Employees.Application.SearchAllByType;

public class CompanyEmployeesByTypeSearcher
{
    private readonly IEmployeesRepository _repository;

    public CompanyEmployeesByTypeSearcher(IEmployeesRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Employee>> SearchAllByType(Guid companyId, EmployeeType type) =>
        await _repository.SearchAllByType(companyId, type);
}
