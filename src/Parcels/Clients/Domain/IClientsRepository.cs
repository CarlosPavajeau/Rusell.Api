using Rusell.Shared.Domain.Repository;

namespace Rusell.Parcels.Clients.Domain;

public interface IClientsRepository : IRepository<Client, ClientId>
{
}
