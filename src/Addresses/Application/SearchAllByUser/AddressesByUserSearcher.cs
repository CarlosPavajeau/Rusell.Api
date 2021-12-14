using Rusell.Addresses.Domain;

namespace Rusell.Addresses.Application.SearchAllByUser;

public class AddressesByUserSearcher
{
    private readonly IAddressesRepository _repository;

    public AddressesByUserSearcher(IAddressesRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Address>> SearchAllByUser(string userId) => await _repository.SearchAllByUser(userId);
}