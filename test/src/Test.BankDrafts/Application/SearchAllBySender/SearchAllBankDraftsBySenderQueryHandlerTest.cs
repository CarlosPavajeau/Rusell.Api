using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using FluentAssertions;
using Moq;
using Rusell.BankDrafts.Application.SearchAllBySender;
using Rusell.BankDrafts.Domain;
using Rusell.Test.BankDrafts.Domain;
using Xunit;

namespace Rusell.Test.BankDrafts.Application.SearchAllBySender;

public class SearchAllBankDraftsBySenderQueryHandlerTest : BankDraftsUnitTestCase
{
    private readonly SearchAllBankDraftsBySenderQueryHandler _handler;
    private readonly string _sender = Guid.NewGuid().ToString();

    public SearchAllBankDraftsBySenderQueryHandlerTest()
    {
        _handler = new SearchAllBankDraftsBySenderQueryHandler(new BankDraftsBySenderSearcher(Repository.Object));

        Repository.Setup(x => x.SearchAll(It.IsAny<Expression<Func<BankDraft, bool>>>()))
            .ReturnsAsync(
                (Expression<Func<BankDraft, bool>> predicate) =>
                    new List<BankDraft>
                    {
                        BankDraftMother.Random().WithSenderId(_sender),
                        BankDraftMother.Random(),
                        BankDraftMother.Random(),
                        BankDraftMother.Random().WithSenderId(_sender)
                    }.Where(predicate.Compile()).ToList());
    }

    [Fact]
    public async void Handle_Should_Return_All_BankDrafts_By_Sender()
    {
        var query = new SearchAllBankDraftsBySenderQuery(_sender);
        var result = await _handler.Handle(query, CancellationToken.None);

        result.Should().NotBeEmpty().And.HaveCount(2);
    }
}
