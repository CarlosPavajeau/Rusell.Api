using Rusell.Parcels.Domain;

namespace Rusell.Parcels.Clients.Domain;

public class Client
{
    public Client(ClientId id, ClientName fullName)
    {
        Id = id;
        FullName = fullName;
    }

    private Client()
    {
        // required by EF
    }

    public ClientId Id { get; set; }
    public ClientName FullName { get; set; }

    public ICollection<Parcel> ParcelsSent { get; set; }
    public ICollection<Parcel> ParcelsReceived { get; set; }
}
