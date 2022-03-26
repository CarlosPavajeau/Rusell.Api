using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Rusell.Parcels.Application.SearchAllByReceiver;
using Rusell.Parcels.Domain;
using Rusell.Test.Parcels.Domain;
using Xunit;

namespace Rusell.Test.Parcels.Application.SearchAllByReceiver;

public class SearchAllParcelsByReceiverQueryHandlerTest : ParcelsUnitTestCase
{
    private readonly SearchAllParcelsByReceiverQueryHandler _handler;
    private readonly string _receiverId = Guid.NewGuid().ToString();

    public SearchAllParcelsByReceiverQueryHandlerTest()
    {
        _handler = new SearchAllParcelsByReceiverQueryHandler(new ParcelsByReceiverSearcher(Repository.Object));

        Repository.Setup(x => x.SearchAll(It.IsAny<Expression<Func<Parcel, bool>>>()))
            .ReturnsAsync(
                (Expression<Func<Parcel, bool>> predicate) =>
                    new List<Parcel>
                    {
                        ParcelMother.Random(Guid.NewGuid()).WithReceiverId(_receiverId),
                        ParcelMother.Random(Guid.NewGuid()).WithReceiverId(_receiverId),
                        ParcelMother.Random(Guid.NewGuid()),
                        ParcelMother.Random(Guid.NewGuid())
                    }.Where(predicate.Compile()).ToList());
    }

    [Fact]
    public async Task SearchAllByReceiver_Should_Return_All_Parcels_By_Receiver()
    {
        var query = new SearchAllParcelsByReceiverQuery(_receiverId);

        var result = await _handler.Handle(query, CancellationToken.None);

        result.Should()
            .NotBeNull()
            .And
            .HaveCount(2);
    }
}
