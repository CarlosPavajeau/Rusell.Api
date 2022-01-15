using Moq;
using Rusell.Test.Shared.Infrastructure;
using Rusell.Vehicles.Domain;

namespace Rusell.Test.Vehicles;

public class VehiclesUnitTestCase : UnitTestCase
{
    protected readonly Mock<IVehiclesRepository> Repository;

    protected VehiclesUnitTestCase()
    {
        Repository = new Mock<IVehiclesRepository>();
    }

    protected void ShouldHaveSave()
    {
        Repository.Verify(x => x.Save(It.IsAny<Vehicle>()), Times.AtLeastOnce());
    }
}
