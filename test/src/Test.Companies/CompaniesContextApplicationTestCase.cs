using System.Net.Http;
using Rusell.Companies.Api;
using Xunit;

namespace Rusell.Test.Companies;

public class CompaniesContextApplicationTestCase : IClassFixture<CompaniesWebApplicationFactory<Program>>
{
    private readonly CompaniesWebApplicationFactory<Program> _factory;
    protected HttpClient Client;

    public CompaniesContextApplicationTestCase(CompaniesWebApplicationFactory<Program> factory)
    {
        _factory = factory;
        Client = _factory.CreateDefaultClient();
    }

    protected void CreateAuthenticatedClient()
    {
        Client = _factory.GetAuthenticatedClient();
    }
}