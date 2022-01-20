using System.Net.Http;
using Rusell.Clients.Api;
using Xunit;

namespace Rusell.Test.Clients;

public class ClientsContextApplicationTestCase : IClassFixture<ClientsWebApplicationFactory<Program>>
{
    private readonly ClientsWebApplicationFactory<Program> _factory;
    protected HttpClient Client;

    public ClientsContextApplicationTestCase(ClientsWebApplicationFactory<Program> factory)
    {
        _factory = factory;
        Client = _factory.CreateDefaultClient();
    }

    protected void CreateAuthenticatedClient()
    {
        Client = _factory.GetAuthenticatedClient();
    }
}
