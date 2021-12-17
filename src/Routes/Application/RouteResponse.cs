namespace Rusell.Routes.Application;

public record RouteResponse(string From, string To, decimal Cost, bool IsCustomerPickedUpAtHome,
    bool IsCustomerDroppedOffAtHome);
