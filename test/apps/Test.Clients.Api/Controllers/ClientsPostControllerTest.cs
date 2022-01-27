using System.Net.Http.Json;
using System.Threading.Tasks;
using Rusell.Clients.Api;
using Rusell.Clients.Api.Controllers.Requests;
using Rusell.Test.Shared.Domain;
using Xunit;

namespace Rusell.Test.Clients.Api.Controllers;

public class ClientsPostControllerTest : ClientsContextApplicationTestCase
{
    public ClientsPostControllerTest(ClientsWebApplicationFactory<Program> factory) : base(factory)
    {
        CreateAuthenticatedClient();
    }

    [Fact]
    public async Task CreateClient_Should_Return_Ok()
    {
        var createClientRequest = new CreateClientRequest(
            WordMother.Random(),
            WordMother.Random(),
            WordMother.Random(),
            WordMother.Random(),
            WordMother.Random(),
            WordMother.Random());

        var response = await Client.PostAsJsonAsync("api/clients", createClientRequest);

        response.EnsureSuccessStatusCode();
    }
}
