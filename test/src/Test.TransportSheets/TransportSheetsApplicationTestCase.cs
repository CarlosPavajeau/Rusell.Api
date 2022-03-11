using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using Rusell.TransportSheets.Api;
using Xunit;

namespace Rusell.Test.TransportSheets;

public class TransportSheetsApplicationTestCase : IClassFixture<TransportSheetsWebApplicationFactory<Program>>
{
    private readonly TransportSheetsWebApplicationFactory<Program> _factory;
    protected HttpClient Client;

    public TransportSheetsApplicationTestCase(TransportSheetsWebApplicationFactory<Program> factory)
    {
        _factory = factory;
        Client = _factory.CreateClient();
    }

    protected void CreateAuthenticatedClient()
    {
        Client = _factory.GetAuthenticatedClient();
    }

    protected IServiceScope CreateScope() => _factory.Server.Services.CreateScope();
}
