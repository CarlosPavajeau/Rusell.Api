using Rusell.Routes.Domain;

namespace Rusell.Routes.Application.Create;

public class RouteCreator
{
    private readonly IRoutesRepository _repository;

    public RouteCreator(IRoutesRepository repository)
    {
        _repository = repository;
    }

    public async Task Create(CreateRouteCommand command)
    {
        var route = Route.Create(
            command.From,
            command.To,
            command.Cost,
            command.IsCustomerPickedUpAtHome,
            command.IsCustomerDroppedOffAtHome,
            command.CompanyId);

        await _repository.Save(route);
    }
}
