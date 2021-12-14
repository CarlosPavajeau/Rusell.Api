using Moq;
using Rusell.Companies.Domain;
using Rusell.Test.Shared.Infrastructure;

namespace Rusell.Test.Companies;

public abstract class CompaniesUnitTestCase : UnitTestCase
{
    protected readonly Mock<ICompaniesRepository> Repository;

    protected CompaniesUnitTestCase()
    {
        Repository = new Mock<ICompaniesRepository>();
    }

    protected void ShouldHaveSave()
    {
        Repository.Verify(x => x.Save(It.IsAny<Company>()), Times.AtLeastOnce());
    }
}