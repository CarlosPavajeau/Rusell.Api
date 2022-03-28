using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Rusell.Parcels.Api;
using Rusell.Parcels.Clients.Domain;
using Rusell.Parcels.Companies.Domain;
using Rusell.Parcels.Employees.Domain;
using Rusell.Test.Shared.Domain;
using Xunit;

namespace Rusell.Test.Parcels;

public class ParcelsContextApplicationTestCase : IClassFixture<ParcelsWebApplicationFactory<Program>>
{
    private readonly ParcelsWebApplicationFactory<Program> _factory;
    protected HttpClient Client;

    public ParcelsContextApplicationTestCase(ParcelsWebApplicationFactory<Program> factory)
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
        var client = new Client(ClientId.From(Guid.NewGuid().ToString()), ClientName.From(WordMother.Random()));

        await clientsRepository.Save(client);

        return client;
    }

    protected async Task<Employee> CreateDispatcher()
    {
        var scope = CreateScope();
        var employeesRepository = scope.ServiceProvider.GetRequiredService<IEmployeesRepository>();
        var employee = new Employee(EmployeeId.From(Guid.NewGuid().ToString()), EmployeeName.From(WordMother.Random()));

        await employeesRepository.Save(employee);

        return employee;
    }

    protected async Task<Company> CreateCompany()
    {
        var scope = CreateScope();
        var companiesRepository = scope.ServiceProvider.GetRequiredService<ICompaniesRepository>();
        var company = new Company(CompanyId.From(Guid.NewGuid()), CompanyName.From(WordMother.Random()));

        await companiesRepository.Save(company);

        return company;
    }
}
