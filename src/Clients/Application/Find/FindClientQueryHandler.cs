using Mapster;
using Rusell.Shared.Domain.Bus.Query;

namespace Rusell.Clients.Application.Find;

public class FindClientQueryHandler : IQueryHandler<FindClientQuery, ClientResponse?>
{
    private readonly ClientFinder _finder;

    public FindClientQueryHandler(ClientFinder finder)
    {
        _finder = finder;
    }

    public async Task<ClientResponse?> Handle(FindClientQuery request, CancellationToken cancellationToken)
    {
        var client = await _finder.Find(request.Id);

        return client?.Adapt<ClientResponse>();
    }
}
