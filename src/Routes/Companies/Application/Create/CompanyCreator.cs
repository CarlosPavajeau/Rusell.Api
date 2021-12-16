using Rusell.Routes.Companies.Domain;

namespace Rusell.Routes.Companies.Application.Create;

public class CompanyCreator
{
    private readonly ICompaniesRepository _repository;

    public CompanyCreator(ICompaniesRepository repository)
    {
        _repository = repository;
    }

    public async Task Create(Guid id, string name)
    {
        var company = new Company
        {
            Id = id,
            Name = name
        };

        await _repository.Save(company);
    }
}
