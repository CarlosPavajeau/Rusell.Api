using Rusell.Shared.Domain.Bus.Query;

namespace Rusell.Routes.Application.SearchAllByCompany;

public record SearchAllRoutesByCompanyQuery(Guid CompanyId) : Query<IEnumerable<RouteResponse>>;
