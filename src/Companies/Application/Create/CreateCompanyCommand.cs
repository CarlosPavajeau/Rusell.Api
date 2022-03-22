using Rusell.Shared.Domain.Bus.Command;

namespace Rusell.Companies.Application.Create;

public record CreateCompanyCommand(string Name, string Nit, string Info, string UserId) : Command
{
    public string UserId { get; set; } = string.Empty;
}
