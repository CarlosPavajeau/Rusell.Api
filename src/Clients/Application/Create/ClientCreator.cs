using Mapster;
using Rusell.Clients.Domain;

namespace Rusell.Clients.Application.Create;

public class ClientCreator
{
    private readonly IClientsRepository _repository;

    public ClientCreator(IClientsRepository repository)
    {
        _repository = repository;
    }

    public async Task Create(CreateClientCommand command)
    {
        var client = command.Adapt<Client>();
        await _repository.Save(client);
    }
}
