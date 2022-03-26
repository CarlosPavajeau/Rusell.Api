using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Rusell.BankDrafts.Api;
using Rusell.BankDrafts.Api.Controllers.Requests;
using Rusell.BankDrafts.Application;
using Rusell.Test.Shared.Domain;
using Xunit;

namespace Rusell.Test.BankDrafts.Api.Controllers;

public class BySenderGetControllerTest : BankDraftsContextApplicationTestCase
{
    public BySenderGetControllerTest(BankDraftsWebApplicationFactory<Program> factory) : base(factory)
    {
        CreateAuthenticatedClient();
    }

    [Fact]
    public async Task GetBySender_Should_Return_All_BankDrafts_By_Sender()
    {
        var sender = await CreateCustomer();
        var receiver = await CreateCustomer();
        var dispatcher = await CreateDispatcher();
        var company = await CreateCompany();

        var createBankDraftRequest = new CreateBankDraftRequest(
            MotherCreator.Random().Decimal(10, 10000),
            MotherCreator.Random().Decimal(10, 10000),
            dispatcher.Id.Value,
            sender.Id.Value,
            receiver.Id.Value
        );

        var createResponse =
            await Client.PostAsJsonAsync($"api/bank-drafts/companies/{company.Id}/bank-drafts", createBankDraftRequest);
        createResponse.EnsureSuccessStatusCode();

        var response =
            await Client.GetAsync($"api/bank-drafts/by-sender/{sender.Id.Value}");
        response.EnsureSuccessStatusCode();

        var bankDrafts = await response.Content.ReadFromJsonAsync<IEnumerable<BankDraftResponse>>();

        bankDrafts.Should().NotBeEmpty();
    }
}
