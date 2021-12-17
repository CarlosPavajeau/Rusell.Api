using Rusell.Shared.Domain.Bus.Command;

namespace Rusell.Routes.Application.Create;

public class CreateRouteCommandHandler : CommandHandler<CreateRouteCommand>
{
    private readonly RouteCreator _creator;


    public CreateRouteCommandHandler(RouteCreator creator)
    {
        _creator = creator;
    }

    protected override async Task Handle(CreateRouteCommand request, CancellationToken cancellationToken)
    {
        await _creator.Create(request);
    }
}
