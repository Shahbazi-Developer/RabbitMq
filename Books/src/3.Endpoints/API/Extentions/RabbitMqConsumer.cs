using Book.Core.Contracts.Books.Commands;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace Book.Endpoints.API.Extentions
{
    public class RabbitMqProducer : IRabbitMqProducer
    {
        private readonly string _hostName = "localhost";        // می‌تونی از IConfiguration هم بگیری
        private readonly string _queueName = "book-events";      // نام صف
        private readonly int _port = 5672;

        public async Task SendMessageAsync<T>(T message)
        {
            var factory = new ConnectionFactory()
            {
                HostName = _hostName,
                Port = _port
            };

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            // تعریف صف با دوام (durable: true)
            channel.QueueDeclare(
                queue: _queueName,
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null
            );

            var json = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(json);

            // تعیین ویژگی‌های پیام به‌صورت persistent (پایدار)
            var properties = channel.CreateBasicProperties();
            properties.Persistent = true;

            channel.BasicPublish(
                exchange: "",
                routingKey: _queueName,
                basicProperties: properties,
                body: body
            );

            await Task.CompletedTask; // چون RabbitMQ sync هست
        }
    }
}
