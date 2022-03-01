using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Rusell.Routes.Addresses.Domain;
using Rusell.Routes.Api;
using Xunit;

namespace Rusell.Test.Routes;

public class RoutesContextApplicationTestCase : IClassFixture<RoutesWebApplicationFactory<Program>>
{
    private readonly RoutesWebApplicationFactory<Program> _factory;
    protected HttpClient Client;

    public RoutesContextApplicationTestCase(RoutesWebApplicationFactory<Program> factory)
    {
        _factory = factory;
        Client = _factory.CreateDefaultClient();
    }

    protected void CreateAuthenticatedClient()
    {
        Client = _factory.GetAuthenticatedClient();
    }

    protected IServiceScope CreateScope() => _factory.Server.Services.CreateScope();

    public async Task<(Guid, Guid)> CreateAddresses()
    {
        var addressFrom = new Address
        {
            Id = Guid.NewGuid(),
            Country = "Colombia",
            State = "Cesar",
            City = "Pueblo Bello"
        };
        var addressTo = new Address
        {
            Id = Guid.NewGuid(),
            Country = "Colombia",
            State = "Cesar",
            City = "Valledupar"
        };

        using var scope = CreateScope();
        var addressRepository = scope.ServiceProvider.GetRequiredService<IAddressesRepository>();

        await addressRepository.Save(addressFrom);
        await addressRepository.Save(addressTo);

        return (addressFrom.Id, addressTo.Id);
    }
}
