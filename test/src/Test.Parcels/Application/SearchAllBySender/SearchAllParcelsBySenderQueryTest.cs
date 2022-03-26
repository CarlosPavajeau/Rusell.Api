using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Rusell.Parcels.Application.SearchAllBySender;
using Rusell.Parcels.Domain;
using Rusell.Test.Parcels.Domain;
using Xunit;

namespace Rusell.Test.Parcels.Application.SearchAllBySender;

public class SearchAllParcelsBySenderQueryTest : ParcelsUnitTestCase
{
    private readonly SearchAllParcelsBySenderQueryHandler _handler;
    private readonly string _senderId = Guid.NewGuid().ToString();

    public SearchAllParcelsBySenderQueryTest()
    {
        _handler = new SearchAllParcelsBySenderQueryHandler(new ParcelsBySenderSearcher(Repository.Object));

        Repository.Setup(x => x.SearchAll(It.IsAny<Expression<Func<Parcel, bool>>>()))
            .ReturnsAsync(
                (Expression<Func<Parcel, bool>> predicate) =>
                    new List<Parcel>
                    {
                        ParcelMother.Random(Guid.NewGuid()).WithSenderId(_senderId),
                        ParcelMother.Random(Guid.NewGuid()).WithSenderId(_senderId),
                        ParcelMother.Random(Guid.NewGuid()),
                        ParcelMother.Random(Guid.NewGuid())
                    }.Where(predicate.Compile()).ToList());
    }

    [Fact]
    public async Task SearchAllByReceiver_Should_Return_All_Parcels_By_Sender()
    {
        var query = new SearchAllParcelsBySenderQuery(_senderId);

        var result = await _handler.Handle(query, CancellationToken.None);

        result.Should()
            .NotBeNull()
            .And
            .HaveCount(2);
    }
}
