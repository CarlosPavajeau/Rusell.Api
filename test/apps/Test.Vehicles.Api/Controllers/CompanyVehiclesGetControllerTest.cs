using System;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Rusell.Test.Shared.Domain;
using Rusell.Vehicles.Api;
using Rusell.Vehicles.Api.Controllers.Requests;
using Rusell.Vehicles.Application;
using Rusell.Vehicles.Employees.Domain;
using Xunit;

namespace Rusell.Test.Vehicles.Api.Controllers;

public class CompanyVehiclesGetControllerTest : VehiclesContextApplicationTestCase
{
    public CompanyVehiclesGetControllerTest(VehiclesWebApplicationFactory<Program> factory) : base(factory)
    {
        CreateAuthenticatedClient();
    }

    [Fact]
    public async Task GetCompanyVehicles_Returns_Ok()
    {
        var (driverId, ownerId) = await CreateDriverAndOwner();
        var createVehicleRequest = new CreateVehicleRequest(
            WordMother.Random(),
            WordMother.Random(),
            WordMother.Random(),
            WordMother.Random(),
            WordMother.Random(),
            WordMother.Random(),
            WordMother.Random(),
            WordMother.Random(),
            10,
            WordMother.Random(),
            WordMother.Random(),
            ownerId,
            driverId);
        var companyId = Guid.NewGuid();

        var createResponse =
            await Client.PostAsJsonAsync($"api/vehicles/companies/{companyId}/vehicles", createVehicleRequest);
        createResponse.EnsureSuccessStatusCode();

        var response = await Client.GetAsync($"api/vehicles/companies/{companyId}/vehicles");
        response.EnsureSuccessStatusCode();

        var vehicles = await response.Content.ReadFromJsonAsync<VehicleResponse[]>();

        vehicles.Should()
            .NotBeNull()
            .And
            .NotBeEmpty();
    }

    private async Task<(string, string)> CreateDriverAndOwner()
    {
        var owner = new Employee(Guid.NewGuid().ToString(), WordMother.Random());
        var driver = new Employee(Guid.NewGuid().ToString(), WordMother.Random());

        using var scope = CreateScope();
        var employeesRepository = scope.ServiceProvider.GetRequiredService<IEmployeesRepository>();

        await employeesRepository.Save(owner);
        await employeesRepository.Save(driver);

        return (driver.Id, owner.Id);
    }
}
