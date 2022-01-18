using Rusell.Shared.Domain.Aggregate;
using Rusell.Shared.Domain.Clients.Domain;
using Rusell.Shared.Domain.ValueObject;

namespace Rusell.Clients.Domain;

public class Client : AggregateRoot
{
    public Client(ClientId id, FirstName firstName, MiddleName middleName, FirstSurname firstSurname,
        SecondSurname secondSurname, PhoneNumber phoneNumber, UserId userId)
    {
        Id = id;
        FirstName = firstName;
        MiddleName = middleName;
        FirstSurname = firstSurname;
        SecondSurname = secondSurname;
        PhoneNumber = phoneNumber;
        UserId = userId;
    }

    internal Client()
    {
    }

    public ClientId Id { get; set; } = default!;
    public FirstName FirstName { get; set; } = default!;
    public MiddleName MiddleName { get; set; } = default!;
    public FirstSurname FirstSurname { get; set; } = default!;
    public SecondSurname SecondSurname { get; set; } = default!;
    public PhoneNumber PhoneNumber { get; set; } = default!;

    public UserId UserId { get; set; } = default!;

    public static Client Create(ClientId id, FirstName firstName, MiddleName middleName, FirstSurname firstSurname,
        SecondSurname secondSurname, PhoneNumber phoneNumber, UserId userId)
    {
        var client = new Client(id, firstName, middleName, firstSurname, secondSurname, phoneNumber, userId);
        client.Record(new ClientCreatedDomainEvent(id, $"{firstName} {middleName} {firstSurname} {secondSurname}"));

        return client;
    }
}
