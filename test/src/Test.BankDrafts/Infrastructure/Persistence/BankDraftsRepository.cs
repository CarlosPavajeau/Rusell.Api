using System;
using System.Threading.Tasks;
using FluentAssertions;
using Rusell.BankDrafts.Domain;
using Rusell.Test.BankDrafts.Domain;
using Xunit;

namespace Rusell.Test.BankDrafts.Infrastructure.Persistence;

public class BankDraftsRepository : BankDraftsContextInfrastructureTestCase
{
    private IBankDraftsRepository Repository => GetService<IBankDraftsRepository>();

    [Fact]
    public async Task Save_Should_Save_A_BankDraft()
    {
        var bankDraft = BankDraftMother.Random();

        await Repository.Save(bankDraft);
    }

    [Fact]
    public async Task SearchAll_Should_Return_All_BankDrafts()
    {
        var bankDraft = BankDraftMother.Random();
        await Repository.Save(bankDraft);

        var bankDrafts = await Repository.SearchAll();

        bankDrafts.Should().NotBeEmpty();
    }

    [Fact]
    public async Task Find_Should_Return_A_BankDraft()
    {
        var bankDraft = BankDraftMother.Random();
        await Repository.Save(bankDraft);

        var bankDraftFound = await Repository.Find(bankDraft.Id);

        bankDraftFound.Should().NotBeNull();
    }

    [Fact]
    public async Task Find_Should_Return_Null()
    {
        var bankDraftFound = await Repository.Find(Guid.NewGuid());

        bankDraftFound.Should().BeNull();
    }
}
