using System;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Rusell.Clients.Api;
using Rusell.Clients.Api.Controllers.Requests;
using Rusell.Clients.Application;
using Rusell.Test.Shared.Domain;
using Xunit;

namespace Rusell.Test.Clients.Api.Controllers;

public class ClientGetControllerTest : ClientsContextApplicationTestCase
{
    public ClientGetControllerTest(ClientsWebApplicationFactory<Program> factory) : base(factory)
    {
        CreateAuthenticatedClient();
    }

    [Fact]
    public async Task GetClient_Should_Return_Ok()
    {
        var createClientRequest = new CreateClientRequest(
            WordMother.Random(),
            WordMother.Random(),
            WordMother.Random(),
            WordMother.Random(),
            WordMother.Random(),
            WordMother.Random());
        var createResponse = await Client.PostAsJsonAsync("api/clients", createClientRequest);
        createResponse.EnsureSuccessStatusCode();

        var response = await Client.GetAsync($"api/clients/{createClientRequest.Id}");
        response.EnsureSuccessStatusCode();

        var client = await response.Content.ReadFromJsonAsync<ClientResponse>();

        client.Should().NotBeNull();
    }

    [Fact]
    public async Task GetClient_Should_Return_NotFound()
    {
        var response = await Client.GetAsync($"api/clients/{Guid.NewGuid()}");
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }
}
