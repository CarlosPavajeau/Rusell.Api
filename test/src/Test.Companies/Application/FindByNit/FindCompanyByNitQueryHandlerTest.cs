using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Rusell.Companies.Application.FindByNit;
using Rusell.Companies.Domain;
using Xunit;

namespace Rusell.Test.Companies.Application.FindByNit;

public class FindCompanyByNitQueryHandlerTest : CompaniesUnitTestCase
{
    private readonly FindCompanyByNitQueryHandler _handler;

    public FindCompanyByNitQueryHandlerTest()
    {
        _handler = new FindCompanyByNitQueryHandler(new CompanyByNitFinder(Repository.Object));

        Repository.Setup(x => x.FindByNit("1234567890")).ReturnsAsync(new Company());
        Repository.Setup(x => x.FindByNit("321")).ReturnsAsync((Company?) null);
    }

    [Fact]
    public async Task FindByNit_Should_Return_Company()
    {
        var result = await _handler.Handle(new FindCompanyByNitQuery("1234567890"), CancellationToken.None);

        result.Should().NotBeNull();
    }

    [Fact]
    public async Task FindByNit_Should_Return_Null()
    {
        var result = await _handler.Handle(new FindCompanyByNitQuery("321"), CancellationToken.None);

        result.Should().BeNull();
    }
}