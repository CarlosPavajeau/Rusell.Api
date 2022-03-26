using System;
using Rusell.Parcels.Clients.Domain;
using Rusell.Parcels.Companies.Domain;
using Rusell.Parcels.Domain;
using Rusell.Parcels.Employees.Domain;
using Rusell.Test.Shared.Domain;

namespace Rusell.Test.Parcels.Domain;

public static class ParcelMother
{
    public static Parcel Random(Guid companyId)
    {
        var dispatcher = new Employee(Guid.NewGuid().ToString(), WordMother.Random());
        var sender = new Client(Guid.NewGuid().ToString(), WordMother.Random());
        var receiver = new Client(Guid.NewGuid().ToString(), WordMother.Random());
        var company = new Company(Guid.NewGuid(), WordMother.Random());

        return new ParcelBuilder()
            .WithId(ParcelId.From(Guid.NewGuid()))
            .WithDate(ParcelDate.From(DateTime.UtcNow))
            .WithDescription(WordMother.Random())
            .WithCost(MotherCreator.Random().Decimal(100, 10000))
            .WithState(ParcelState.Created)
            .WithVehicleLicensePlate(VehicleLicensePlate.From(WordMother.Random()))
            .WithDispatcher(dispatcher)
            .WithDispatcherId(dispatcher.Id)
            .WithSender(sender)
            .WithSenderId(sender.Id)
            .WithReceiver(receiver)
            .WithReceiverId(receiver.Id)
            .WithCompany(company)
            .Build();
    }

    internal static Parcel WithSenderId(this Parcel parcel, string senderId)
    {
        parcel.SenderId = ClientId.From(senderId);
        return parcel;
    }

    internal static Parcel WithReceiverId(this Parcel parcel, string receiverId)
    {
        parcel.ReceiverId = ClientId.From(receiverId);
        return parcel;
    }
}
