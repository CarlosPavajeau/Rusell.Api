using Rusell.Shared.Domain.Repository;

namespace Rusell.Companies.Domain;

public interface ICompaniesRepository : IRepository<Company, CompanyId>
{
    Task<Company?> FindByNit(string nit);
}