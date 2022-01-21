using Rusell.BankDrafts.Domain;

namespace Rusell.BankDrafts.Clients.Domain;

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

    public ICollection<BankDraft> BankDraftsSent { get; set; }
    public ICollection<BankDraft> BankDraftsReceived { get; set; }
}
