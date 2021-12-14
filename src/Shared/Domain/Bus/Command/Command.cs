using MediatR;

namespace Rusell.Shared.Domain.Bus.Command;

public abstract record Command : IRequest;

public abstract record Command<TResponse> : IRequest<TResponse>;