using MediatR;

namespace Rusell.Shared.Domain.Bus.Query;

public abstract record Query<TResponse> : IRequest<TResponse>;