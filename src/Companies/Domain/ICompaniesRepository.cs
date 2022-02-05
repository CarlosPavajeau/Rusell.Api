using Rusell.Shared.Domain.Repository;
using Rusell.Shared.Domain.ValueObject;

namespace Rusell.Companies.Domain;

public interface ICompaniesRepository : IRepository<Company, CompanyId>
{
    Task<Company?> FindByNit(string nit);
    Task<Company?> FindByUser(UserId userId);
}
