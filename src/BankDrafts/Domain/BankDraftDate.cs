using ValueOf;

namespace Rusell.BankDrafts.Domain;

public class BankDraftDate : ValueOf<DateTime, BankDraftDate>
{
    public static implicit operator DateTime(BankDraftDate bankDraftDate) => bankDraftDate.Value;
    public static implicit operator BankDraftDate(DateTime bankDraftDate) => From(bankDraftDate);
}
