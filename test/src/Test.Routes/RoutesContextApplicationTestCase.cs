using System.Net.Http;
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
}