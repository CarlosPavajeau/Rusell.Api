using MediatR;

namespace Rusell.Shared.Domain.Bus.Event;

public interface IDomainEventSubscriber<in TDomain> : INotificationHandler<TDomain> where TDomain : DomainEvent
{
}