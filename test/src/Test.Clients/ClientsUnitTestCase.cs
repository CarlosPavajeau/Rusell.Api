using Mapster;
using Moq;
using Rusell.Clients.Domain;
using Rusell.Shared.Helpers;
using Rusell.Test.Shared.Infrastructure;

namespace Rusell.Test.Clients;

public class ClientsUnitTestCase : UnitTestCase
{
    protected readonly Mock<IClientsRepository> Repository;

    public ClientsUnitTestCase()
    {
        Repository = new Mock<IClientsRepository>();
        TypeAdapterConfig.GlobalSettings.Scan(AssemblyHelper.GetInstance(Assemblies.Clients));
    }

    protected void ShouldHaveSave()
    {
        Repository.Verify(x => x.Save(It.IsAny<Client>()), Times.AtLeastOnce());
    }
}
