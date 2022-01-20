using System;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Rusell.Test.Shared.Domain;
using Rusell.Vehicles.Api;
using Rusell.Vehicles.Api.Controllers.Requests;
using Xunit;

namespace Rusell.Test.Vehicles.Api.Controllers;

public class VehiclesPostControllerTest : VehiclesContextApplicationTestCase
{
    public VehiclesPostControllerTest(VehiclesWebApplicationFactory<Program> factory) : base(factory)
    {
        CreateAuthenticatedClient();
    }

    [Fact]
    public async Task CreateVehicle_Should_Return_Ok()
    {
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
            WordMother.Random(),
            WordMother.Random());
        var companyId = Guid.NewGuid();

        var createResponse =
            await Client.PostAsJsonAsync($"api/vehicles/companies/{companyId}/vehicles", createVehicleRequest);

        createResponse.EnsureSuccessStatusCode();
    }
}
