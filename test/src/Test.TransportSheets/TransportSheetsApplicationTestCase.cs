using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Rusell.Test.Shared.Domain;
using Rusell.TransportSheets.Api;
using Rusell.TransportSheets.Employees.Domain;
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

    protected async Task<string> CreateDispatcher()
    {
        var dispatcher = new Employee(Guid.NewGuid().ToString(), WordMother.Random());

        using var scope = CreateScope();
        var employeesRepository = scope.ServiceProvider.GetRequiredService<IEmployeesRepository>();

        await employeesRepository.Save(dispatcher);

        return dispatcher.Id;
    }
}
