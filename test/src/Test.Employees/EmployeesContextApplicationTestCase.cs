using System.Net.Http;
using Rusell.Employees.Api;
using Xunit;

namespace Rusell.Test.Employees;

public class EmployeesContextApplicationTestCase : IClassFixture<EmployeesWebApplicationFactory<Program>>
{
    private readonly EmployeesWebApplicationFactory<Program> _factory;
    protected HttpClient Client;

    public EmployeesContextApplicationTestCase(EmployeesWebApplicationFactory<Program> factory)
    {
        _factory = factory;
        Client = _factory.CreateDefaultClient();
    }

    protected void CreateAuthenticatedClient()
    {
        Client = _factory.GetAuthenticatedClient();
    }
}
