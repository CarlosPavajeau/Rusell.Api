using Rusell.Routes.Companies.Domain;
using Rusell.Shared.Domain.Repository;

namespace Rusell.Routes.Domain;

public interface IRoutesRepository : IRepository<Route, RouteId>
{
    public Task<IEnumerable<Route>> SearchAllByCompany(CompanyId companyId);
}
