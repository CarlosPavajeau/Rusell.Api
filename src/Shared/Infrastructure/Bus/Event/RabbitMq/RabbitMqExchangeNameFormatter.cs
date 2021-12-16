namespace Rusell.Shared.Infrastructure.Bus.Event.RabbitMq;

public static class RabbitMqExchangeNameFormatter
{
    public static string Retry(string exchangeName) => $"retry-{exchangeName}";

    public static string DeadLetter(string exchangeName) => $"dead_letter-{exchangeName}";
}
