using System;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Rusell.Routes.Api;
using Rusell.Routes.Api.Controllers.Requests;
using Xunit;

namespace Rusell.Test.Routes.Api.Controllers;

public class RoutesPostControllerTest : RoutesContextApplicationTestCase
{
    public RoutesPostControllerTest(RoutesWebApplicationFactory<Program> factory) : base(factory)
    {
        CreateAuthenticatedClient();
    }

    [Fact]
    public async Task CreateRoute_Should_Return_Ok()
    {
        var createRouteRequest = new CreateRouteRequest(Guid.NewGuid(), Guid.NewGuid(), 15000, false, false);
        var companyId = Guid.NewGuid();

        var response = await Client.PostAsJsonAsync($"api/routes/companies/{companyId}/routes", createRouteRequest);

        response.EnsureSuccessStatusCode();
    }
}
