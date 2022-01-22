using Rusell.BankDrafts.Domain;

namespace Rusell.BankDrafts.Application;

public record BankDraftResponse(
    DateTime Date,
    decimal Amount,
    decimal Cost,
    decimal Total,
    BankDraftState State,
    string DispatcherName,
    string SenderName,
    string ReceiverName,
    string CompanyName);
