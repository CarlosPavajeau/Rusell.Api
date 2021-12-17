using Mapster;
using Rusell.Addresses.Domain;
using Rusell.Shared.Domain.Address.Domain;
using Rusell.Shared.Domain.Bus.Event;

namespace Rusell.Addresses.Application.Create;

public class AddressCreator
{
    private readonly IAddressesRepository _repository;
    private readonly IEventBus _eventBus;

    public AddressCreator(IAddressesRepository repository, IEventBus eventBus)
    {
        _repository = repository;
        _eventBus = eventBus;
    }

    public async Task Create(CreateAddressCommand command)
    {
        var address = command.Adapt<Address>();

        address.Record(new AddressCreatedDomainEvent(address.Id.ToString(), address.Country, address.State,
            address.City));

        await _repository.Save(address);

        await _eventBus.Publish(address.PullDomainEvents());
    }
}
