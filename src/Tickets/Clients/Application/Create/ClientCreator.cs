using Rusell.Tickets.Clients.Domain;

namespace Rusell.Tickets.Clients.Application.Create;

public class ClientCreator
{
    private readonly IClientsRepository _repository;

    public ClientCreator(IClientsRepository repository)
    {
        _repository = repository;
    }

    public async Task Create(ClientId id, ClientName fullName)
    {
        var client = new Client(id, fullName);
        await _repository.Save(client);
    }
}
