using Rusell.Shared.Domain.Bus.Command;

namespace Rusell.BankDrafts.Application.Create;

public record CreateBankDraftCommand(
    decimal Amount,
    decimal Cost,
    string DispatcherId,
    string SenderId,
    string ReceiverId,
    Guid CompanyId) : Command
{
    public Guid CompanyId { get; set; }
}
