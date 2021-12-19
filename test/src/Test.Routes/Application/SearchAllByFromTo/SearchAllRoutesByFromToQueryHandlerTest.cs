using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Rusell.Routes.Application.SearchAllByFromTo;
using Rusell.Routes.Domain;
using Rusell.Test.Shared.Domain;
using Xunit;
using Address = Rusell.Routes.Addresses.Domain.Address;

namespace Rusell.Test.Routes.Application.SearchAllByFromTo;

public class SearchAllRoutesByFromToQueryHandlerTest : RoutesUnitTestCase
{
    private readonly SearchAllRoutesByFromToQueryHandler _handler;

    public SearchAllRoutesByFromToQueryHandlerTest()
    {
        _handler = new SearchAllRoutesByFromToQueryHandler(new RoutesByFromToSearcher(Repository.Object));

        Repository.Setup(x =>
                x.SearchAllByFromTo(It.IsAny<Address>(), It.IsAny<Address>()))
            .ReturnsAsync(new List<Route>
            {
                new(),
                new()
            });
    }

    [Fact]
    public async Task SearchAllRoutesByCompanyQueryHandler_Should_Return_All_Routes()
    {
        var from = new Rusell.Routes.Application.SearchAllByFromTo.Address(WordMother.Random(), WordMother.Random(),
            WordMother.Random());
        var to = new Rusell.Routes.Application.SearchAllByFromTo.Address(WordMother.Random(), WordMother.Random(),
            WordMother.Random());
        var query = new SearchAllRoutesByFromToQuery(from, to);

        var result = await _handler.Handle(query, CancellationToken.None);

        result.Should().NotBeEmpty()
            .And
            .HaveCount(2);
    }
}
