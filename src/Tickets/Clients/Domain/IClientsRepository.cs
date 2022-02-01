using Rusell.Shared.Domain.Repository;

namespace Rusell.Tickets.Clients.Domain;

public interface IClientsRepository : IRepository<Client, ClientId>
{
}
