using System;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Rusell.Routes.Api;
using Rusell.Routes.Api.Controllers.Requests;
using Rusell.Routes.Application;
using Xunit;

namespace Rusell.Test.Routes.Api.Controllers;

public class CompanyRoutesGetControllerTest : RoutesContextApplicationTestCase
{
    public CompanyRoutesGetControllerTest(RoutesWebApplicationFactory<Program> factory) : base(factory)
    {
        CreateAuthenticatedClient();
    }

    [Fact]
    public async Task GetCompanyRoutes_Returns_Ok()
    {
        var createRouteRequest = new CreateRouteRequest(Guid.NewGuid(), Guid.NewGuid(), 15000, false, false);
        var companyId = Guid.NewGuid();

        var createResponse =
            await Client.PostAsJsonAsync($"api/routes/companies/{companyId}/routes", createRouteRequest);
        createResponse.EnsureSuccessStatusCode();

        var response = await Client.GetAsync($"api/routes/companies/{companyId}/routes");
        response.EnsureSuccessStatusCode();

        var routes = await response.Content.ReadFromJsonAsync<RouteResponse[]>();

        routes.Should().NotBeNull();
        routes.Should().NotBeEmpty();
    }
}
