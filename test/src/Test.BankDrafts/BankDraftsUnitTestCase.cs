using Mapster;
using Moq;
using Rusell.BankDrafts.Domain;
using Rusell.Shared.Helpers;
using Rusell.Test.Shared.Infrastructure;

namespace Rusell.Test.BankDrafts;

public class BankDraftsUnitTestCase : UnitTestCase
{
    protected readonly Mock<IBankDraftsRepository> Repository;

    protected BankDraftsUnitTestCase()
    {
        Repository = new Mock<IBankDraftsRepository>();
        TypeAdapterConfig.GlobalSettings.Scan(AssemblyHelper.GetInstance(Assemblies.BankDrafts));
    }

    protected void ShouldHaveSave()
    {
        Repository.Verify(x => x.Save(It.IsAny<BankDraft>()), Times.AtLeastOnce());
    }
}
