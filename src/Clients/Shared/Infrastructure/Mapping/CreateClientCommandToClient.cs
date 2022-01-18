using Mapster;
using Rusell.Clients.Application.Create;
using Rusell.Clients.Domain;

namespace Rusell.Clients.Shared.Infrastructure.Mapping;

public class CreateClientCommandToClient : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateClientCommand, Client>()
            .MapWith(from => Client.Create(
                from.Id,
                from.FirstName,
                from.MiddleName,
                from.FirstSurname,
                from.SecondSurname,
                from.PhoneNumber,
                from.UserId));
    }
}
