namespace Rusell.Routes.Application;

public record RouteResponse(string Id, string From, string To, decimal Cost, bool IsCustomerPickedUpAtHome,
    bool IsCustomerDroppedOffAtHome);
