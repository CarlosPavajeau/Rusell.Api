using Mapster;
using Rusell.Addresses.Domain;

namespace Rusell.Addresses.Application.Create;

public class AddressCreator
{
  private readonly IAddressesRepository _repository;

  public AddressCreator(IAddressesRepository repository)
  {
    _repository = repository;
  }

  public async Task Create(CreateAddressCommand command)
  {
    var address = command.Adapt<Address>();
    await _repository.Save(address);
  }
}