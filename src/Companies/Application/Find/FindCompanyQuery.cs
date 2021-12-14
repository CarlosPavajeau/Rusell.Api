using Rusell.Shared.Domain.Bus.Query;

namespace Rusell.Companies.Application.Find;

public record FindCompanyQuery(string Id) : Query<CompanyResponse>;