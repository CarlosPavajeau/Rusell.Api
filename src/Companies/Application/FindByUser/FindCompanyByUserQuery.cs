using Rusell.Shared.Domain.Bus.Query;

namespace Rusell.Companies.Application.FindByUser;

public record FindCompanyByUserQuery(string UserId) : Query<CompanyResponse?>;
