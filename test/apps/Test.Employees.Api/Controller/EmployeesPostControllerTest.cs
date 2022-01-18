using System;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Rusell.Employees.Api;
using Rusell.Employees.Api.Controllers.Requests;
using Rusell.Employees.Domain;
using Rusell.Test.Shared.Domain;
using Xunit;

namespace Rusell.Test.Employees.Api.Controller;

public class EmployeesPostControllerTest : EmployeesContextApplicationTestCase
{
    public EmployeesPostControllerTest(EmployeesWebApplicationFactory<Program> factory) : base(factory)
    {
        CreateAuthenticatedClient();
    }

    [Fact]
    public async Task Create_Employee_Should_Return_Ok()
    {
        var createEmployeeRequest = new CreateEmployeeRequest(
            WordMother.Random(),
            WordMother.Random(),
            WordMother.Random(),
            WordMother.Random(),
            WordMother.Random(),
            WordMother.Random(),
            WordMother.Random(),
            EmployeeType.Driver);
        var companyId = Guid.NewGuid();

        var response =
            await Client.PostAsJsonAsync($"api/employees/companies/{companyId}/employees", createEmployeeRequest);

        response.EnsureSuccessStatusCode();
    }
}
