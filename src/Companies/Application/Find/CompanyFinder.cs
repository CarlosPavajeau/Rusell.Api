using Rusell.Companies.Domain;

namespace Rusell.Companies.Application.Find;

public class CompanyFinder
{
    private readonly ICompaniesRepository _repository;

    public CompanyFinder(ICompaniesRepository repository)
    {
        _repository = repository;
    }

    public async Task<Company> Find(string id)
    {
        return await _repository.Find(CompanyId.From(Guid.Parse(id)));
    }
}
