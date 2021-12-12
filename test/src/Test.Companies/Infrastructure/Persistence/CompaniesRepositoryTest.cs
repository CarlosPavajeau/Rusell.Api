using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Rusell.Companies.Domain;
using Rusell.Test.Shared.Domain;
using Xunit;

namespace Rusell.Test.Companies.Infrastructure.Persistence;

public class CompaniesRepositoryTest : CompaniesContextInfrastructureTestCase
{
    private ICompaniesRepository Repository => GetService<ICompaniesRepository>();

    [Fact]
    public async Task Save_ShouldSaveACompany()
    {
        var company = new Company
        {
            Id = CompanyId.From(Guid.NewGuid()),
            Name = WordMother.Random(),
            Nit = WordMother.Random(),
            Info = WordMother.Random()
        };

        await Repository.Save(company);
    }

    [Fact]
    public async Task SearchAll_ShouldReturnAllCompanies()
    {
        var companies = new List<Company>();
        for (var i = 0; i < 10; i++)
        {
            companies.Add(new Company
            {
                Id = CompanyId.From(Guid.NewGuid()),
                Name = WordMother.Random(),
                Nit = WordMother.Random(),
                Info = WordMother.Random()
            });
        }

        foreach (var company in companies)
        {
            await Repository.Save(company);
        }

        var result = await Repository.SearchAll();

        result.Should().HaveCount(companies.Count);
    }

    [Fact]
    public async Task Find_ShouldReturnACompany()
    {
        var company = new Company
        {
            Id = CompanyId.From(Guid.NewGuid()),
            Name = WordMother.Random(),
            Nit = WordMother.Random(),
            Info = WordMother.Random()
        };

        await Repository.Save(company);

        var result = await Repository.Find(company.Id);

        company.Id.Should().Be(result.Id);
    }

    [Fact]
    public async Task Find_ShouldReturnNull()
    {
        var result = await Repository.Find(CompanyId.From(Guid.NewGuid()));

        result.Should().BeNull();
    }
}
