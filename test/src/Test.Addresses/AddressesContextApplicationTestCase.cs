using System.Net.Http;
using Rusell.Addresses.Api;
using Xunit;

namespace Test.Addresses;

public class AddressesContextApplicationTestCase : IClassFixture<AddressesWebApplicationFactory<Program>>
{
    private readonly AddressesWebApplicationFactory<Program> _factory;
    protected HttpClient Client;

    public AddressesContextApplicationTestCase(AddressesWebApplicationFactory<Program> factory)
    {
        _factory = factory;
        Client = _factory.CreateDefaultClient();
    }

    protected void CreateAuthenticatedClient()
    {
        Client = _factory.GetAuthenticatedClient();
    }
}