using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Rusell.Addresses.Api;
using Rusell.Addresses.Api.Controllers.Requests;
using Rusell.Test.Shared.Domain;
using Xunit;

namespace Rusell.Test.Addresses.Api.Controllers;

public class AddressesControllerTest : AddressesContextApplicationTestCase
{
    public AddressesControllerTest(AddressesWebApplicationFactory<Program> factory) : base(factory)
    {
        CreateAuthenticatedClient();
    }

    [Fact]
    public async Task CreateAddress_Should_Return_Ok()
    {
        var address = new CreateAddressRequest
        {
            Country = WordMother.Random(),
            State = WordMother.Random(),
            City = WordMother.Random(),
            Neighborhood = WordMother.Random(),
            StreetName = WordMother.Random(),
            Intersection = WordMother.Random(),
            StreetNumber = WordMother.Random(),
            Comments = WordMother.Random()
        };

        var response = await Client.PostAsync("/api/addresses",
            new StringContent(JsonSerializer.Serialize(address), Encoding.UTF8, "application/json"));

        response.EnsureSuccessStatusCode();
    }

    [Fact]
    public async Task GetAddresses_Should_Return_Ok()
    {
        var response = await Client.GetAsync("/api/addresses");

        response.EnsureSuccessStatusCode();
    }

    [Fact]
    public async Task GetAddress_Should_Return_NotFound()
    {
        var response = await Client.GetAsync($"/api/addresses/{Guid.NewGuid().ToString()}");

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
}
