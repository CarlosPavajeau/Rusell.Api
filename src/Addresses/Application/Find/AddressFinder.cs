using Rusell.Addresses.Domain;

namespace Rusell.Addresses.Application.Find;

public class AddressFinder
{
    private readonly IAddressesRepository _repository;

    public AddressFinder(IAddressesRepository repository)
    {
        _repository = repository;
    }

    public async Task<Address> Find(string id) => await _repository.Find(AddressId.From(Guid.Parse(id)));
}
