using System;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Rusell.Test.Shared.Domain;
using Rusell.Vehicles.Api;
using Rusell.Vehicles.Api.Controllers.Requests;
using Xunit;

namespace Rusell.Test.Vehicles.Api.Controllers;

public class VehicleLegalInformationPostControllerTest : VehiclesContextApplicationTestCase
{
    public VehicleLegalInformationPostControllerTest(VehiclesWebApplicationFactory<Program> factory) : base(factory)
    {
        CreateAuthenticatedClient();
    }

    [Fact]
    public async Task Create_Vehicle_Legal_Information_Should_Return_Ok()
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

        var createLegalInformationRequest =
            new CreateVehicleLegalInformationRequest(WordMother.Random(), DateTime.Now, DateTime.Now.AddYears(5));
        var response = await Client.PostAsJsonAsync(
            $"api/vehicles/{createVehicleRequest.LicensePlate}/legal-information", createLegalInformationRequest);

        response.EnsureSuccessStatusCode();
    }

    [Fact]
    public async Task Create_Vehicle_Legal_Information_Should_Return_NotFound()
    {
        var createLegalInformationRequest =
            new CreateVehicleLegalInformationRequest(WordMother.Random(), DateTime.Now, DateTime.Now.AddYears(5));
        var response = await Client.PostAsJsonAsync(
            $"api/vehicles/{WordMother.Random()}/legal-information", createLegalInformationRequest);

        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }
}
