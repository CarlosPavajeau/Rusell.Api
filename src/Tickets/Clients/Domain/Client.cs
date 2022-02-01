using Rusell.Tickets.Domain;

namespace Rusell.Tickets.Clients.Domain;

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

    public ClientId Id { get; set; } = default!;
    public ClientName FullName { get; set; } = default!;

    public ICollection<Ticket> Tickets { get; set; }
}
