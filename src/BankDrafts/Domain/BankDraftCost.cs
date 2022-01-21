using ValueOf;

namespace Rusell.BankDrafts.Domain;

public class BankDraftCost : ValueOf<decimal, BankDraftCost>
{
    public static implicit operator decimal(BankDraftCost bankDraftCost) => bankDraftCost.Value;
    public static implicit operator BankDraftCost(decimal bankDraftCost) => From(bankDraftCost);
}
