using ValueOf;

namespace Rusell.Parcels.Clients.Domain;

public class ClientName : ValueOf<string, ClientName>
{
    public static implicit operator string(ClientName clientName) => clientName.Value;
    public static implicit operator ClientName(string clientName) => From(clientName);
}
