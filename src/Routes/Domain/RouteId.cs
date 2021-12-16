using ValueOf;

namespace Rusell.Routes.Domain;

public class RouteId : ValueOf<Guid, RouteId>
{
    public static implicit operator Guid(RouteId routeId) => routeId.Value;
    public static implicit operator RouteId(Guid routeId) => From(routeId);
}
