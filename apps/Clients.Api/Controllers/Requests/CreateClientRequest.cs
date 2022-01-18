namespace Rusell.Clients.Api.Controllers.Requests;

public record CreateClientRequest(string Id, string FirstName, string MiddleName, string FirstSurname,
    string SecondSurname, string PhoneNumber);
