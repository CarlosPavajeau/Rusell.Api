using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using Rusell.BankDrafts.Api;
using Xunit;

namespace Rusell.Test.BankDrafts;

public class BankDraftsContextApplicationTestCase : IClassFixture<BankDraftsWebApplicationFactory<Program>>
{
    private readonly BankDraftsWebApplicationFactory<Program> _factory;
    protected HttpClient Client;

    public BankDraftsContextApplicationTestCase(BankDraftsWebApplicationFactory<Program> factory)
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
