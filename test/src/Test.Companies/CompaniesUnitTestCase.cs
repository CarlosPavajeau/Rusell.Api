using Mapster;
using Moq;
using Rusell.Companies.Domain;
using Rusell.Shared.Helpers;
using Rusell.Test.Shared.Infrastructure;

namespace Rusell.Test.Companies;

public abstract class CompaniesUnitTestCase : UnitTestCase
{
    protected readonly Mock<ICompaniesRepository> Repository;

    protected CompaniesUnitTestCase()
    {
        Repository = new Mock<ICompaniesRepository>();
        TypeAdapterConfig.GlobalSettings.Scan(AssemblyHelper.GetInstance(Assemblies.Companies));
    }

    protected void ShouldHaveSave()
    {
        Repository.Verify(x => x.Save(It.IsAny<Company>()), Times.AtLeastOnce());
    }
}
