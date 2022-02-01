using ValueOf;

namespace Rusell.Tickets.Clients.Domain;

public class ClientId : ValueOf<string, ClientId>
{
    public static implicit operator string(ClientId clientId) => clientId.Value;
    public static implicit operator ClientId(string clientId) => From(clientId);
}
