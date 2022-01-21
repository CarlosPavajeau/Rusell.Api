namespace Rusell.BankDrafts.Api.Controllers.Requests;

public record CreateBankDraftRequest(
    decimal Amount,
    decimal Cost,
    string DispatcherId,
    string SenderId,
    string ReceiverId);
