using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using Rusell.Parcels.Api;
using Xunit;

namespace Rusell.Test.Parcels;

public class VehiclesContextApplicationTestCase : IClassFixture<ParcelsWebApplicationFactory<Program>>
{
    private readonly ParcelsWebApplicationFactory<Program> _factory;
    protected HttpClient Client;

    public VehiclesContextApplicationTestCase(ParcelsWebApplicationFactory<Program> factory)
    {
        _factory = factory;
        Client = _factory.CreateDefaultClient();
    }

    protected void CreateAuthenticatedClient()
    {
        Client = _factory.GetAuthenticatedClient();
    }

    protected IServiceScope CreateScope() => _factory.Server.Services.CreateScope();
}
