using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace Rusell.Shared.Infrastructure.Bus.Event.RabbitMq;

public class RabbitMqConfig
{
    private static IConnection? _connection;
    private static IModel? _channel;

    public RabbitMqConfig(IOptions<RabbitMqConfigParams> rabbitMqParams)
    {
        var configParams = rabbitMqParams.Value;

        ConnectionFactory = new ConnectionFactory
        {
            HostName = configParams.HostName,
            UserName = configParams.Username,
            Password = configParams.Password,
            Port = configParams.Port
        };
    }

    private ConnectionFactory ConnectionFactory { get; }

    public IConnection Connection() => _connection ??= ConnectionFactory.CreateConnection();

    public IModel Channel() => _channel ??= Connection().CreateModel();
}
