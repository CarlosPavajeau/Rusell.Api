using System;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Rusell.Routes.Addresses.Domain;
using Rusell.Routes.Api;
using Rusell.Routes.Api.Controllers.Requests;
using Rusell.Routes.Application;
using Xunit;

namespace Rusell.Test.Routes.Api.Controllers;

public class RoutesFromToGetControllerTest : RoutesContextApplicationTestCase
{
    public RoutesFromToGetControllerTest(RoutesWebApplicationFactory<Program> factory) : base(factory)
    {
        CreateAuthenticatedClient();
    }

    [Fact]
    public async Task GetRoutesFromTo_Should_Return_All_Routes_From_To()
    {
        var (fromId, toId) = await CreateAddresses();

        var createRouteRequest = new CreateRouteRequest(fromId, toId, 15000, false, false);
        var companyId = Guid.NewGuid();

        var createResponse =
            await Client.PostAsJsonAsync($"api/routes/companies/{companyId}/routes", createRouteRequest);
        createResponse.EnsureSuccessStatusCode();

        var response =
            await Client.GetAsync(
                "api/routes?from.country=Colombia&from.state=Cesar&from.city=Pueblo Bello&to.country=Colombia&to.state=Cesar&to.city=Valledupar");
        response.EnsureSuccessStatusCode();

        var routes = await response.Content.ReadFromJsonAsync<RouteResponse[]>();

        routes.Should().NotBeNull();
        routes.Should().NotBeEmpty();
    }

    private async Task<(Guid, Guid)> CreateAddresses()
    {
        var addressFrom = new Address
        {
            Id = Guid.NewGuid(),
            Country = "Colombia",
            State = "Cesar",
            City = "Pueblo Bello"
        };
        var addressTo = new Address
        {
            Id = Guid.NewGuid(),
            Country = "Colombia",
            State = "Cesar",
            City = "Valledupar"
        };

        using var scope = CreateScope();
        var addressRepository = scope.ServiceProvider.GetRequiredService<IAddressesRepository>();

        await addressRepository.Save(addressFrom);
        await addressRepository.Save(addressTo);

        return (addressFrom.Id, addressTo.Id);
    }
}
