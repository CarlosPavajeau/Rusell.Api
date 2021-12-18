using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Rusell.Companies.Api;
using Rusell.Companies.Api.Controllers.Requests;
using Rusell.Companies.Application;
using Rusell.Test.Shared.Domain;
using Xunit;

namespace Rusell.Test.Companies.Api.Controller;

public class CompaniesControllerTest : CompaniesContextApplicationTestCase
{
    public CompaniesControllerTest(CompaniesWebApplicationFactory<Program> factory) : base(factory)
    {
        CreateAuthenticatedClient();
    }

    [Fact]
    public async Task CreateCompany_Should_Return_Ok()
    {
        var createCompanyRequest =
            new CreateCompanyRequest(WordMother.Random(), WordMother.Random(), WordMother.Random());
        var response = await Client.PostAsync("/api/companies",
            new StringContent(JsonSerializer.Serialize(createCompanyRequest), Encoding.UTF8, "application/json"));

        response.EnsureSuccessStatusCode();
    }

    [Fact]
    public async Task GetCompany_ShouldReturn_NotFound()
    {
        var response = await Client.GetAsync($"/api/companies/{Guid.NewGuid()}");
        Assert.Equal(404, (int) response.StatusCode);
    }

    [Fact]
    public async Task GetCompanyByNit_ShouldReturn_Company()
    {
        var createCompanyRequest =
            new CreateCompanyRequest(WordMother.Random(), "123", WordMother.Random());
        var createResponse = await Client.PostAsync("/api/companies",
            new StringContent(JsonSerializer.Serialize(createCompanyRequest), Encoding.UTF8, "application/json"));

        createResponse.EnsureSuccessStatusCode();

        var response = await Client.GetAsync("/api/companies/by-nit/123");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        var companyResponse = JsonSerializer.Deserialize<CompanyResponse>(content);

        companyResponse.Should().NotBeNull();
    }
}
