using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using FluentAssertions;
using Moq;
using Rusell.BankDrafts.Application.SearchAllByReceiverAndState;
using Rusell.BankDrafts.Domain;
using Rusell.Test.BankDrafts.Domain;
using Xunit;

namespace Rusell.Test.BankDrafts.Application.SearchAllByReceiverAndState;

public class SearchAllBankDraftsByReceiverAndStateQueryHandlerTest : BankDraftsUnitTestCase
{
    private readonly SearchAllBankDraftsByReceiverAndStateQueryHandler _handler;
    private readonly string _receiver = Guid.NewGuid().ToString();

    public SearchAllBankDraftsByReceiverAndStateQueryHandlerTest()
    {
        _handler = new SearchAllBankDraftsByReceiverAndStateQueryHandler(
            new BankDraftsByReceiverAndStateSearcher(Repository.Object));

        Repository.Setup(x => x.SearchAll(It.IsAny<Expression<Func<BankDraft, bool>>>()))
            .ReturnsAsync(
                (Expression<Func<BankDraft, bool>> predicate) =>
                    new List<BankDraft>
                    {
                        BankDraftMother.Random().WithReceiverId(_receiver).WithState(BankDraftState.Created),
                        BankDraftMother.Random(),
                        BankDraftMother.Random().WithReceiverId(_receiver).WithState(BankDraftState.Created),
                        BankDraftMother.Random()
                    }.Where(predicate.Compile()).ToList());
    }

    [Fact]
    public async void Handle_Should_Return_All_BankDrafts_By_Receiver_And_State()
    {
        var query = new SearchAllBankDraftsByReceiverAndStateQuery(_receiver, BankDraftState.Created);
        var result = await _handler.Handle(query, CancellationToken.None);

        result.Should().NotBeEmpty().And.HaveCount(2);
    }
}
