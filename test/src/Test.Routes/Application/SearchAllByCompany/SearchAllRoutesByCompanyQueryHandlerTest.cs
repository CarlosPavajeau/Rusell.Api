using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Rusell.Routes.Application.SearchAllByCompany;
using Rusell.Routes.Companies.Domain;
using Rusell.Routes.Domain;
using Xunit;

namespace Rusell.Test.Routes.Application.SearchAllByCompany;

public class SearchAllRoutesByCompanyQueryHandlerTest : RoutesUnitTestCase
{
    private readonly SearchAllRoutesByCompanyQueryHandler _handler;

    public SearchAllRoutesByCompanyQueryHandlerTest()
    {
        _handler = new SearchAllRoutesByCompanyQueryHandler(new RoutesByCompanySearcher(Repository.Object));

        Repository.Setup(x => x.SearchAllByCompany(It.IsAny<CompanyId>())).ReturnsAsync(new List<Route>
        {
            new(),
            new()
        });
    }

    [Fact]
    public async Task SearchAllRoutesByCompanyQueryHandler_Should_Return_All_Routes()
    {
        var query = new SearchAllRoutesByCompanyQuery(Guid.NewGuid());

        var result = await _handler.Handle(query, CancellationToken.None);

        result.Should().NotBeEmpty();
    }
}
