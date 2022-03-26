using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Rusell.BankDrafts.Api;
using Rusell.BankDrafts.Clients.Domain;
using Rusell.BankDrafts.Companies.Domain;
using Rusell.BankDrafts.Employees.Domain;
using Rusell.Test.Shared.Domain;
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
