using System;
using System.Threading.Tasks;
using FluentAssertions;
using Rusell.Routes.Addresses.Domain;
using Rusell.Routes.Companies.Domain;
using Rusell.Routes.Domain;
using Rusell.Test.Routes.Domain;
using Rusell.Test.Shared.Domain;
using Xunit;

namespace Rusell.Test.Routes.Infrastructure.Persistence;

public class RoutesRepositoryTest : RoutesContextInfrastructureTestCase
{
    private IRoutesRepository Repository => GetService<IRoutesRepository>();
    private IAddressesRepository AddressesRepository => GetService<IAddressesRepository>();

    [Fact]
    public async Task Save_Should_Save_A_Route()
    {
        var route = RouteMother.Random(Guid.NewGuid());

        await Repository.Save(route);
    }

    [Fact]
    public async Task SearchAllByCompany_Should_Return_All_Routes()
    {
        var companyId = CompanyId.From(Guid.NewGuid());
        var routes = new[]
        {
            RouteMother.Random(companyId),
            RouteMother.Random(companyId)
        };

        foreach (var route in routes) await Repository.Save(route);

        var result = await Repository.SearchAllByCompany(companyId);

        result.Should().BeEquivalentTo(routes);
    }

    [Fact]
    public async Task SearchAllByFromTo_Should_Return_All_Routes()
    {
        var from = new Address
        {
            Id = AddressId.From(Guid.NewGuid()),
            Country = WordMother.Random(),
            City = WordMother.Random(),
            State = WordMother.Random()
        };

        var to = new Address
        {
            Id = AddressId.From(Guid.NewGuid()),
            Country = WordMother.Random(),
            City = WordMother.Random(),
            State = WordMother.Random()
        };

        await AddressesRepository.Save(from);
        await AddressesRepository.Save(to);

        var route = new Route
        {
            FromId = from.Id,
            ToId = to.Id,
            CompanyId = CompanyId.From(Guid.NewGuid()),
            Cost = 15000,
            IsCustomerDroppedOffAtHome = true,
            IsCustomerPickedUpAtHome = false
        };

        await Repository.Save(route);

        var routes = await Repository.SearchAllByFromTo(from, to);

        routes.Should()
            .NotBeEmpty()
            .And
            .HaveCount(1);
    }
}
