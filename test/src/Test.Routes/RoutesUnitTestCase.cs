using Moq;
using Rusell.Routes.Domain;
using Rusell.Test.Shared.Infrastructure;

namespace Rusell.Test.Routes;

public class RoutesUnitTestCase : UnitTestCase
{
    protected readonly Mock<IRoutesRepository> Repository;

    protected RoutesUnitTestCase()
    {
        Repository = new Mock<IRoutesRepository>();
    }

    protected void ShouldHaveSave()
    {
        Repository.Verify(x => x.Save(It.IsAny<Route>()), Times.AtLeastOnce());
    }
}
