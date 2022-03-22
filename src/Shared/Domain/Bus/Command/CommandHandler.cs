using MediatR;

namespace Rusell.Shared.Domain.Bus.Command;

public abstract class CommandHandler<TCommand> : AsyncRequestHandler<TCommand> where TCommand : Command
{
}
