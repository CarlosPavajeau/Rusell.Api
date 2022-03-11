using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using Rusell.Tickets.Api;
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
}
