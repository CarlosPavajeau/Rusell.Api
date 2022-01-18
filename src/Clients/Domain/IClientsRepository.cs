using Rusell.Shared.Domain.Repository;

namespace Rusell.Clients.Domain;

public interface IClientsRepository : IRepository<Client, ClientId>
{
}
