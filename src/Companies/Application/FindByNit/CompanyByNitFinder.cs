using Rusell.Companies.Domain;

namespace Rusell.Companies.Application.FindByNit;

public class CompanyByNitFinder
{
  private readonly ICompaniesRepository _repository;

  public CompanyByNitFinder(ICompaniesRepository repository)
  {
    _repository = repository;
  }

  public async Task<Company?> FindByNit(string nit) => await _repository.FindByNit(nit);
}