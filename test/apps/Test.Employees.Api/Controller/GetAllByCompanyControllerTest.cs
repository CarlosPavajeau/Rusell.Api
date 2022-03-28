using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Rusell.Employees.Api;
using Rusell.Employees.Api.Controllers.Requests;
using Rusell.Employees.Application;
using Rusell.Employees.Domain;
using Rusell.Test.Shared.Domain;
using Xunit;

namespace Rusell.Test.Employees.Api.Controller;

public class GetAllByCompanyControllerTest : EmployeesContextApplicationTestCase
{
    public GetAllByCompanyControllerTest(EmployeesWebApplicationFactory<Program> factory) : base(factory)
    {
        CreateAuthenticatedClient();
    }

    [Fact]
    public async Task GetEmployees_Should_Return_All_Company_Employees()
    {
        var createEmployeeRequest = new CreateEmployeeRequest(
            WordMother.Random(),
            WordMother.Random(),
            WordMother.Random(),
            WordMother.Random(),
            WordMother.Random(),
            WordMother.Random(),
            WordMother.Random(),
            EmployeeType.Driver,
            Guid.NewGuid().ToString());
        var companyId = Guid.NewGuid();
        var createResponse =
            await Client.PostAsJsonAsync($"api/employees/companies/{companyId}/employees", createEmployeeRequest);
        createResponse.EnsureSuccessStatusCode();

        var response = await Client.GetAsync($"api/employees/companies/{companyId}/employees");
        response.EnsureSuccessStatusCode();

        var employees = await response.Content.ReadFromJsonAsync<List<EmployeeResponse>>();

        employees.Should()
            .NotBeEmpty()
            .And
            .OnlyContain(e => e.CompanyId == companyId);
    }
}
