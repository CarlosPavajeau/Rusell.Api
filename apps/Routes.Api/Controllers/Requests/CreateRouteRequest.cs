namespace Rusell.Routes.Api.Controllers.Requests;

public record CreateRouteRequest(Guid From, Guid To, decimal Cost, bool IsCustomerPickedUpAtHome,
    bool IsCustomerDroppedOffAtHome);
