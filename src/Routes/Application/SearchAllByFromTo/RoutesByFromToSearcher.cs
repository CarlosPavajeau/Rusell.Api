using Rusell.Routes.Domain;

namespace Rusell.Routes.Application.SearchAllByFromTo;

public class RoutesByFromToSearcher
{
    private readonly IRoutesRepository _repository;

    public RoutesByFromToSearcher(IRoutesRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Route>>
        SearchAllByFromTo(Addresses.Domain.Address from, Addresses.Domain.Address to) =>
        await _repository.SearchAllByFromTo(from, to);
}
