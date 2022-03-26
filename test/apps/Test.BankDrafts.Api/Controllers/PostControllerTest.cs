using System;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Rusell.BankDrafts.Api;
using Rusell.BankDrafts.Api.Controllers.Requests;
using Rusell.Test.Shared.Domain;
using Xunit;

namespace Rusell.Test.BankDrafts.Api.Controllers;

public class PostControllerTest : BankDraftsContextApplicationTestCase
{
    public PostControllerTest(BankDraftsWebApplicationFactory<Program> factory) : base(factory)
    {
        CreateAuthenticatedClient();
    }

    [Fact]
    public async Task Create_BankDraft_Should_Return_Ok()
    {
        var createBankDraftRequest = new CreateBankDraftRequest(
            MotherCreator.Random().Decimal(),
            MotherCreator.Random().Decimal(),
            Guid.NewGuid().ToString(),
            Guid.NewGuid().ToString(),
            Guid.NewGuid().ToString()
        );

        var response = await Client.PostAsJsonAsync($"api/bank-drafts/companies/{Guid.NewGuid()}/bank-drafts",
            createBankDraftRequest);

        response.EnsureSuccessStatusCode();
    }
}
