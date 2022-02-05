using Rusell.Companies.Domain;
using Rusell.Shared.Domain.ValueObject;

namespace Rusell.Companies.Application.FindByUser;

public class CompanyByUserFinder
{
    private readonly ICompaniesRepository _repository;

    public CompanyByUserFinder(ICompaniesRepository repository)
    {
        _repository = repository;
    }

    public async Task<Company?> FindByUser(UserId userId) => await _repository.FindByUser(userId);
}
