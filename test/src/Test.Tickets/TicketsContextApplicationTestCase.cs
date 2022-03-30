using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Rusell.Test.Shared.Domain;
using Rusell.Tickets.Api;
using Rusell.Tickets.Clients.Domain;
using Xunit;

namespace Rusell.Test.Tickets;

public class TicketsContextApplicationTestCase : IClassFixture<TicketsWebApplicationFactory<Program>>
{
    private readonly TicketsWebApplicationFactory<Program> _factory;
    protected HttpClient Client;

    public TicketsContextApplicationTestCase(TicketsWebApplicationFactory<Program> factory)
    {
        _factory = factory;
        Client = _factory.CreateDefaultClient();
    }

    protected void CreateAuthenticatedClient()
    {
        Client = _factory.GetAuthenticatedClient();
    }

    protected IServiceScope CreateScope() => _factory.Server.Services.CreateScope();

    protected async Task<Client> CreateCustomer()
    {
        var scope = CreateScope();
        var clientsRepository = scope.ServiceProvider.GetRequiredService<IClientsRepository>();

        var client = new Client(ClientId.From(Guid.NewGuid().ToString()), WordMother.Random());
        await clientsRepository.Save(client);

        return client;
    }
}
