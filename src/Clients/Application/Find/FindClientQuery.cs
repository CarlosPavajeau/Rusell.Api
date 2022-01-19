using Rusell.Shared.Domain.Bus.Query;

namespace Rusell.Clients.Application.Find;

public record FindClientQuery(string Id) : Query<ClientResponse?>;
