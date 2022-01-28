using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Rusell.BankDrafts.Application.Create;
using Rusell.Test.Shared.Domain;
using Xunit;

namespace Rusell.Test.BankDrafts.Application.Create;

public class CreateBankDraftCommandHandlerTest : BankDraftsUnitTestCase
{
    private readonly IRequestHandler<CreateBankDraftCommand, Unit> _handler;

    public CreateBankDraftCommandHandlerTest()
    {
        _handler = new CreateBankDraftCommandHandler(new BankDraftCreator(Repository.Object));
    }

    [Fact]
    public async Task Create_Should_Create_A_BankDraft()
    {
        var command = new CreateBankDraftCommand(
            10000,
            1000,
            WordMother.Random(),
            WordMother.Random(),
            WordMother.Random(),
            Guid.NewGuid());

        await _handler.Handle(command, CancellationToken.None);

        ShouldHaveSave();
    }
}
