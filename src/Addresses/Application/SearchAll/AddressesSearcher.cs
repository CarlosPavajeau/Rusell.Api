using Rusell.Addresses.Domain;

namespace Rusell.Addresses.Application.SearchAll;

public class AddressesSearcher
{
    private readonly IAddressesRepository _repository;

    public AddressesSearcher(IAddressesRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Address>> SearchAll() => await _repository.SearchAll();
}