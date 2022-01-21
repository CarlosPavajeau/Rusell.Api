using ValueOf;

namespace Rusell.BankDrafts.Domain;

public class BankDraftAmount : ValueOf<decimal, BankDraftAmount>
{
    public static implicit operator decimal(BankDraftAmount bankDraftAmount) => bankDraftAmount.Value;
    public static implicit operator BankDraftAmount(decimal bankDraftQuantity) => From(bankDraftQuantity);
}
