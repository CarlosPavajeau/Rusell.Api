using Rusell.Shared.Domain.Bus.Query;

namespace Rusell.Companies.Application.FindByNit;

public record FindCompanyByNitQuery(string Nit) : Query<CompanyResponse?>;
