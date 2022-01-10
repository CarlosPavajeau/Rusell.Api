using System;
using System.Threading.Tasks;
using FluentAssertions;
using Rusell.Routes.Addresses.Domain;
using Rusell.Test.Shared.Domain;
using Xunit;

namespace Rusell.Test.Routes.Addresses.Infrastructure.Persistence;

public class AddressesRepositoryTest : RoutesContextInfrastructureTestCase
{
    private IAddressesRepository Repository => GetService<IAddressesRepository>();

    [Fact]
    public async Task Find_Should_Return_Address()
    {
        var address = new Address
        {
            Id = AddressId.From(Guid.NewGuid()),
            Country = WordMother.Random(),
            State = WordMother.Random(),
            City = WordMother.Random()
        };

        await Repository.Save(address);

        var foundAddress = await Repository.Find(address.Id);

        foundAddress.Should().NotBeNull();
    }
}
