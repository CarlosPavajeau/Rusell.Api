using Rusell.Shared.Domain.Bus.Query;

namespace Rusell.Routes.Application.SearchAllByFromTo;

public record Address(string Country, string State, string City);

public record SearchAllRoutesByFromToQuery(Address From, Address To) : Query<IEnumerable<RouteResponse>>;
