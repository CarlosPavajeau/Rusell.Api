using Rusell.BankDrafts.Clients.Domain;

namespace Rusell.BankDrafts.Clients.Application.Create;

public class ClientCreator
{
    private readonly IClientsRepository _repository;

    public ClientCreator(IClientsRepository repository)
    {
        _repository = repository;
    }

    public async Task Create(ClientId id, ClientName name)
    {
        var client = new Client(id, name);
        await _repository.Save(client);
    }
}
