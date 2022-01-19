using Rusell.Clients.Domain;

namespace Rusell.Clients.Application.Find;

public class ClientFinder
{
    private readonly IClientsRepository _repository;

    public ClientFinder(IClientsRepository repository)
    {
        _repository = repository;
    }

    public async Task<Client?> Find(ClientId clientId) => await _repository.Find(clientId);
}
