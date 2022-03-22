using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Rusell.Companies.Application.Find;
using Rusell.Companies.Domain;
using Rusell.Test.Shared.Domain;
using Xunit;

namespace Rusell.Test.Companies.Application.Find;

public class FindCompanyQueryHandlerTest : CompaniesUnitTestCase
{
    private readonly Guid _companyIdFound = Guid.NewGuid();
    private readonly Guid _companyIdNotFound = Guid.NewGuid();
    private readonly FindCompanyQueryHandler _handler;


    public FindCompanyQueryHandlerTest()
    {
        _handler = new FindCompanyQueryHandler(new CompanyFinder(Repository.Object));

        Repository.Setup(x => x.Find(_companyIdFound)).ReturnsAsync(Company.Create(WordMother.Random(),
            WordMother.Random(), WordMother.Random(),
            WordMother.Random()));
        Repository.Setup(x => x.Find(_companyIdNotFound)).ReturnsAsync((Company?) null);
    }

    [Fact]
    public async Task Find_Should_Return_Company()
    {
        var result = await _handler.Handle(new FindCompanyQuery(_companyIdFound.ToString()), CancellationToken.None);

        result.Should().NotBeNull();
    }

    [Fact]
    public async Task Find_Should_Return_Null()
    {
        var result = await _handler.Handle(new FindCompanyQuery(_companyIdNotFound.ToString()), CancellationToken.None);

        result.Should().BeNull();
    }
}
