using System.Net.Http;
using Rusell.Vehicles.Api;
using Xunit;

namespace Rusell.Test.Vehicles;

public class VehiclesContextApplicationTestCase : IClassFixture<VehiclesWebApplicationFactory<Program>>
{
    private readonly VehiclesWebApplicationFactory<Program> _factory;
    protected HttpClient Client;

    public VehiclesContextApplicationTestCase(VehiclesWebApplicationFactory<Program> factory)
    {
        _factory = factory;
        Client = _factory.CreateDefaultClient();
    }

    protected void CreateAuthenticatedClient()
    {
        Client = _factory.GetAuthenticatedClient();
    }
}
