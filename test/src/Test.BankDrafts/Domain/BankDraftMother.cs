using System;
using Rusell.BankDrafts.Clients.Domain;
using Rusell.BankDrafts.Companies.Domain;
using Rusell.BankDrafts.Domain;
using Rusell.BankDrafts.Employees.Domain;
using Rusell.Test.Shared.Domain;

namespace Rusell.Test.BankDrafts.Domain;

public static class BankDraftMother
{
    public static BankDraft Random()
    {
        var dispatcher = new Employee(Guid.NewGuid().ToString(), WordMother.Random());
        var sender = new Client(Guid.NewGuid().ToString(), WordMother.Random());
        var receiver = new Client(Guid.NewGuid().ToString(), WordMother.Random());
        var company = new Company(Guid.NewGuid(), WordMother.Random());

        return new BankDraftBuilder()
            .WithId(Guid.NewGuid())
            .WithDate(DateTime.UtcNow)
            .WithAmount(10000)
            .WithCost(1000)
            .WithTotal(10000 + 1000)
            .WithState(BankDraftState.Created)
            .WithDispatcherId(dispatcher.Id)
            .WithDispatcher(dispatcher)
            .WithSenderId(sender.Id)
            .WithSender(sender)
            .WithReceiverId(receiver.Id)
            .WithReceiver(receiver)
            .WithCompanyId(company.Id)
            .WithCompany(company)
            .Build();
    }

    internal static BankDraft WithSenderId(this BankDraft bankDraft, string senderId)
    {
        bankDraft.SenderId = senderId;
        bankDraft.Sender.Id = senderId;

        return bankDraft;
    }

    internal static BankDraft WithReceiverId(this BankDraft bankDraft, string receiverId)
    {
        bankDraft.ReceiverId = receiverId;
        bankDraft.Receiver.Id = receiverId;

        return bankDraft;
    }

    internal static BankDraft WithState(this BankDraft bankDraft, BankDraftState state)
    {
        bankDraft.State = state;

        return bankDraft;
    }
}
