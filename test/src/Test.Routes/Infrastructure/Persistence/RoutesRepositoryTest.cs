using System;
using System.Threading.Tasks;
using Rusell.Routes.Addresses.Domain;
using Rusell.Routes.Companies.Domain;
using Rusell.Routes.Domain;
using Xunit;

namespace Rusell.Test.Routes.Infrastructure.Persistence;

public class RoutesRepositoryTest : RoutesContextInfrastructureTestCase
{
    private IRoutesRepository Repository => GetService<IRoutesRepository>();

    [Fact]
    public async Task Save_Should_Save_A_Route()
    {
        var route = new Route
        {
            FromId = AddressId.From(Guid.NewGuid()),
            ToId = AddressId.From(Guid.NewGuid()),
            CompanyId = CompanyId.From(Guid.NewGuid()),
            Cost = 15000,
            IsCustomerDroppedOffAtHome = true,
            IsCustomerPickedUpAtHome = false
        };

        await Repository.Save(route);
    }
}
