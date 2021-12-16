namespace Rusell.Shared.Domain.Bus.Event;

public interface IDomainEventDeserializer
{
    DomainEvent Deserialize(string body);
}
