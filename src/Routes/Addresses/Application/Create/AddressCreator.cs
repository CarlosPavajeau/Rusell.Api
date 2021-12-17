using Rusell.Routes.Addresses.Domain;

namespace Rusell.Routes.Addresses.Application.Create;

public class AddressCreator
{
    private readonly IAddressesRepository _repository;

    public AddressCreator(IAddressesRepository repository)
    {
        _repository = repository;
    }

    public async Task Create(Guid id, string country, string state, string city)
    {
        var address = new Address
        {
            Id = id,
            Country = country,
            State = state,
            City = city
        };

        await _repository.Save(address);
    }
}
