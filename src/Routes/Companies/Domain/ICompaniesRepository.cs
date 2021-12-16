using Rusell.Shared.Domain.Repository;

namespace Rusell.Routes.Companies.Domain;

public interface ICompaniesRepository : IRepository<Company, CompanyId>
{
}
