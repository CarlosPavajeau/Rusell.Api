namespace Rusell.Shared.Domain.Bus.Event;

public interface IDomainEventsConsumer
{
    Task Consume();
}
