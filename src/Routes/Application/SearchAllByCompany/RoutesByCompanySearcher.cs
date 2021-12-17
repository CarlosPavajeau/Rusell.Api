using Rusell.Routes.Companies.Domain;
using Rusell.Routes.Domain;

namespace Rusell.Routes.Application.SearchAllByCompany;

public class RoutesByCompanySearcher
{
    private readonly IRoutesRepository _repository;

    public RoutesByCompanySearcher(IRoutesRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Route>> SearchAllByCompany(CompanyId companyId) =>
        await _repository.SearchAllByCompany(companyId);
}
