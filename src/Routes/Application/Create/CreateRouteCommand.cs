using Rusell.Shared.Domain.Bus.Command;

namespace Rusell.Routes.Application.Create;

public record CreateRouteCommand(Guid From, Guid To, decimal Cost, bool IsCustomerPickedUpAtHome,
    bool IsCustomerDroppedOffAtHome, Guid CompanyId) : Command
{
    public Guid CompanyId { get; set; }
}
