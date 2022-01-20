using Moq;
using Rusell.Addresses.Domain;
using Rusell.Test.Shared.Infrastructure;

namespace Rusell.Test.Addresses;

public abstract class AddressesUnitTestCase : UnitTestCase
{
    protected readonly Mock<IAddressesRepository> Repository;

    protected AddressesUnitTestCase()
    {
        Repository = new Mock<IAddressesRepository>();
    }

    protected void ShouldHaveSave()
    {
        Repository.Verify(x => x.Save(It.IsAny<Address>()), Times.AtLeastOnce());
    }
}
