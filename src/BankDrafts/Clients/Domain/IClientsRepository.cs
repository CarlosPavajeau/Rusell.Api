using Rusell.Shared.Domain.Repository;

namespace Rusell.BankDrafts.Clients.Domain;

public interface IClientsRepository : IRepository<Client, ClientId>
{
}
