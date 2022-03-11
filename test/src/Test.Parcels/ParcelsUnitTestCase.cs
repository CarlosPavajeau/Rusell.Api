using Moq;
using Rusell.Parcels.Domain;
using Rusell.Test.Shared.Infrastructure;

namespace Rusell.Test.Parcels;

public class ParcelsUnitTestCase : UnitTestCase
{
    protected readonly Mock<IParcelsRepository> Repository;

    protected ParcelsUnitTestCase()
    {
        Repository = new Mock<IParcelsRepository>();
    }
}
