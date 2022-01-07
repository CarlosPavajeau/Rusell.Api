using Rusell.Employees.Domain;

namespace Rusell.Employees.Application.SearchAllByCompany;

public class EmployeesByCompanySearcher
{
    private readonly IEmployeesRepository _repository;

    public EmployeesByCompanySearcher(IEmployeesRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Employee>> SearchAllByCompany(CompanyId companyId) =>
        await _repository.SearchAllByCompany(companyId);
}
