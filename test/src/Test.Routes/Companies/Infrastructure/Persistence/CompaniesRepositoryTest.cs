using System;
using System.Threading.Tasks;
using FluentAssertions;
using Rusell.Routes.Companies.Domain;
using Rusell.Test.Shared.Domain;
using Xunit;

namespace Rusell.Test.Routes.Companies.Infrastructure.Persistence;

public class CompaniesRepositoryTest : RoutesContextInfrastructureTestCase
{
    private ICompaniesRepository Repository => GetService<ICompaniesRepository>();

    [Fact]
    public async Task Find_Should_Return_Company()
    {
        var companyId = Guid.NewGuid();
        var company = new Company
        {
            Id = companyId,
            Name = WordMother.Random()
        };

        await Repository.Save(company);

        var result = await Repository.Find(companyId);

        result.Should().NotBeNull();
    }
}
