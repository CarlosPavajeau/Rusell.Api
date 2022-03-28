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

public class GetAllByCompanyAndTypeControllerTest : EmployeesContextApplicationTestCase
{
    public GetAllByCompanyAndTypeControllerTest(EmployeesWebApplicationFactory<Program> factory) : base(factory)
    {
        CreateAuthenticatedClient();
    }

    [Fact]
    public async Task GetEmployeesByType_Should_Return_All_Company_Employees_By_Type()
    {
        var companyId = Guid.NewGuid();
        await CreateEmployees(companyId);

        var response =
            await Client.GetAsync(
                $"api/employees/companies/{companyId}/employees/by-type/{EmployeeType.Dispatcher:d}");
        response.EnsureSuccessStatusCode();

        var employees = await response.Content.ReadFromJsonAsync<List<EmployeeResponse>>();

        employees.Should()
            .NotBeEmpty()
            .And
            .Contain(e => e.Type == EmployeeType.Dispatcher);
    }

    private async Task CreateEmployees(Guid companyId)
    {
        const int numberOfEmployees = 10;
        for (var i = 0; i < numberOfEmployees; i++)
        {
            var createEmployeeRequest = new CreateEmployeeRequest(
                Guid.NewGuid().ToString(),
                WordMother.Random(),
                WordMother.Random(),
                WordMother.Random(),
                WordMother.Random(),
                WordMother.Random(),
                WordMother.Random(),
                i % 2 == 0 ? EmployeeType.Dispatcher : MotherCreator.Random().Enum<EmployeeType>(),
                Guid.NewGuid().ToString()
            );

            var createResponse =
                await Client.PostAsJsonAsync($"api/employees/companies/{companyId}/employees", createEmployeeRequest);
            createResponse.EnsureSuccessStatusCode();
        }
    }
}
