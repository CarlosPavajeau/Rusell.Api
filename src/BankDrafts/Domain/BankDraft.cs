using Rusell.BankDrafts.Clients.Domain;
using Rusell.BankDrafts.Companies.Domain;
using Rusell.BankDrafts.Employees.Domain;
using Rusell.Shared.Domain.Aggregate;

namespace Rusell.BankDrafts.Domain;

public class BankDraft : AggregateRoot
{
    public BankDraft(BankDraftDate date, BankDraftAmount amount, BankDraftCost cost,
        BankDraftTotal total, EmployeeId dispatcherId, ClientId senderId, ClientId receiverId)
    {
        Id = BankDraftId.From(Guid.NewGuid());
        Date = date;
        Amount = amount;
        Cost = cost;
        Total = total;
        DispatcherId = dispatcherId;
        SenderId = senderId;
        ReceiverId = receiverId;
        State = BankDraftState.Created;
    }

    internal BankDraft()
    {
        // required by EF
    }

    public BankDraftId Id { get; set; }
    public BankDraftDate Date { get; set; } = default!;
    public BankDraftAmount Amount { get; set; } = default!;
    public BankDraftCost Cost { get; set; } = default!;
    public BankDraftTotal Total { get; set; } = default!;
    public BankDraftState State { get; set; }

    public EmployeeId DispatcherId { get; set; } = default!;
    public Employee Dispatcher { get; set; }

    public ClientId SenderId { get; set; } = default!;
    public Client Sender { get; set; }

    public ClientId ReceiverId { get; set; } = default!;
    public Client Receiver { get; set; }

    public CompanyId CompanyId { get; set; } = default!;
    public Company Company { get; set; }
}
