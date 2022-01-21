using ValueOf;

namespace Rusell.BankDrafts.Domain;

public class BankDraftTotal : ValueOf<decimal, BankDraftTotal>
{
    public static implicit operator decimal(BankDraftTotal bankDraftTotal) => bankDraftTotal.Value;
    public static implicit operator BankDraftTotal(decimal bankDraftTotal) => From(bankDraftTotal);
}
