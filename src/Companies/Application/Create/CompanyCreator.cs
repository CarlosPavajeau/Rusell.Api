using Mapster;
using Rusell.Companies.Domain;

namespace Rusell.Companies.Application.Create;

public class CompanyCreator
{
    private readonly ICompaniesRepository _repository;

    public CompanyCreator(ICompaniesRepository repository)
    {
        _repository = repository;
    }

    public async Task Create(CreateCompanyCommand command)
    {
        var company = command.Adapt<Company>();
        await _repository.Save(company);
    }
}
