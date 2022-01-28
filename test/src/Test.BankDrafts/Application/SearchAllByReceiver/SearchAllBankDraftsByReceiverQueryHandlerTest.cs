using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using FluentAssertions;
using Moq;
using Rusell.BankDrafts.Application.SearchAllByReceiver;
using Rusell.BankDrafts.Domain;
using Rusell.Test.BankDrafts.Domain;
using Xunit;

namespace Rusell.Test.BankDrafts.Application.SearchAllByReceiver;

public class SearchAllBankDraftsByReceiverQueryHandlerTest : BankDraftsUnitTestCase
{
    private readonly SearchAllBankDraftsByReceiverQueryHandler _handler;
    private readonly string _receiver = Guid.NewGuid().ToString();

    public SearchAllBankDraftsByReceiverQueryHandlerTest()
    {
        _handler = new SearchAllBankDraftsByReceiverQueryHandler(new BankDraftsByReceiverSearcher(Repository.Object));

        Repository.Setup(x => x.SearchAll(It.IsAny<Expression<Func<BankDraft, bool>>>()))
            .ReturnsAsync(
                (Expression<Func<BankDraft, bool>> predicate) =>
                    new List<BankDraft>
                    {
                        BankDraftMother.Random().WithReceiverId(_receiver),
                        BankDraftMother.Random(),
                        BankDraftMother.Random(),
                        BankDraftMother.Random().WithReceiverId(_receiver)
                    }.Where(predicate.Compile()).ToList());
    }

    [Fact]
    public async void Handle_Should_Return_All_BankDrafts_By_Receiver()
    {
        var query = new SearchAllBankDraftsByReceiverQuery(_receiver);
        var result = await _handler.Handle(query, CancellationToken.None);

        result.Should().NotBeEmpty().And.HaveCount(2);
    }
}
