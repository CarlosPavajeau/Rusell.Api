using ValueOf;

namespace Rusell.BankDrafts.Domain;

public class BankDraftId : ValueOf<Guid, BankDraftId>
{
    public static implicit operator Guid(BankDraftId bankDraftId) => bankDraftId.Value;
    public static implicit operator BankDraftId(Guid bankDraftId) => From(bankDraftId);
}
