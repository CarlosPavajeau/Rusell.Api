using Mapster;
using Rusell.Clients.Domain;
using Rusell.Shared.Domain.Bus.Event;

namespace Rusell.Clients.Application.Create;

public class ClientCreator
{
    private readonly IClientsRepository _repository;
    private readonly IEventBus _eventBus;

    public ClientCreator(IClientsRepository repository, IEventBus eventBus)
    {
        _repository = repository;
        _eventBus = eventBus;
    }

    public async Task Create(CreateClientCommand command)
    {
        var client = command.Adapt<Client>();

        await _repository.Save(client);
        await _eventBus.Publish(client.PullDomainEvents());
    }
}
