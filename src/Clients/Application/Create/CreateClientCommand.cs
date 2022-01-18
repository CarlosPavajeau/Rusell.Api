using Rusell.Shared.Domain.Bus.Command;

namespace Rusell.Clients.Application.Create;

public record CreateClientCommand(string Id, string FirstName, string MiddleName, string FirstSurname,
    string SecondSurname, string PhoneNumber, string UserId) : Command
{
    public string UserId { get; set; } = default!;
}
