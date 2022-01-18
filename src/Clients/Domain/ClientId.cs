using ValueOf;

namespace Rusell.Clients.Domain;

public class ClientId : ValueOf<string, ClientId>
{
    public static implicit operator string(ClientId typeTo) => typeTo.Value;
    public static implicit operator ClientId(string typeTo) => From(typeTo);
}
