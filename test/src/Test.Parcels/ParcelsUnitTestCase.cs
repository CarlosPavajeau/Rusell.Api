using Mapster;
using Moq;
using Rusell.Parcels.Domain;
using Rusell.Shared.Helpers;
using Rusell.Test.Shared.Infrastructure;

namespace Rusell.Test.Parcels;

public class ParcelsUnitTestCase : UnitTestCase
{
    protected readonly Mock<IParcelsRepository> Repository;

    protected ParcelsUnitTestCase()
    {
        Repository = new Mock<IParcelsRepository>();
        TypeAdapterConfig.GlobalSettings.Scan(AssemblyHelper.GetInstance(Assemblies.Parcels));
    }

    protected void ShouldHaveSave()
    {
        Repository.Verify(x => x.Save(It.IsAny<Parcel>()), Times.AtLeastOnce());
    }
}
