using System;
using System.Threading.Tasks;
using FluentAssertions;
using Rusell.Addresses.Domain;
using Rusell.Test.Shared.Domain;
using Xunit;

namespace Test.Addresses.Infrastructure.Persistence;

public class AddressesRepositoryTest : AddressesContextInfrastructureTestCase
{
    private IAddressesRepository Repository => GetService<IAddressesRepository>();

    [Fact]
    public async Task Save_ShouldSaveAnAddress()
    {
        var address = new Address
        {
            Id = AddressId.From(Guid.NewGuid()),
            Country = WordMother.Random(),
            State = WordMother.Random(),
            City = WordMother.Random(),
            Neighborhood = WordMother.Random(),
            StreetName = WordMother.Random(),
            Intersection = WordMother.Random(),
            StreetNumber = WordMother.Random(),
            Comments = WordMother.Random()
        };

        await Repository.Save(address);
    }

    [Fact]
    public async Task SearchAll_ShouldReturnAllAddresses()
    {
        var address = new Address
        {
            Id = AddressId.From(Guid.NewGuid()),
            Country = WordMother.Random(),
            State = WordMother.Random(),
            City = WordMother.Random(),
            Neighborhood = WordMother.Random(),
            StreetName = WordMother.Random(),
            Intersection = WordMother.Random(),
            StreetNumber = WordMother.Random(),
            Comments = WordMother.Random()
        };

        await Repository.Save(address);

        var addresses = await Repository.SearchAll();

        addresses.Should().NotBeEmpty();
    }

    [Fact]
    public async Task Find_ShouldReturnAnAddress()
    {
        var address = new Address
        {
            Id = AddressId.From(Guid.NewGuid()),
            Country = WordMother.Random(),
            State = WordMother.Random(),
            City = WordMother.Random(),
            Neighborhood = WordMother.Random(),
            StreetName = WordMother.Random(),
            Intersection = WordMother.Random(),
            StreetNumber = WordMother.Random(),
            Comments = WordMother.Random()
        };

        await Repository.Save(address);

        var foundAddress = await Repository.Find(address.Id);

        foundAddress.Should().NotBeNull();
    }

    [Fact]
    public async Task Find_ShouldReturnNull()
    {
        var result = await Repository.Find(AddressId.From(Guid.NewGuid()));

        result.Should().BeNull();
    }
}