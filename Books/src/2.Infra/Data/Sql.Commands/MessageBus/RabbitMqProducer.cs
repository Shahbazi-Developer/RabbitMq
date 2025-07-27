using Book.Core.Contracts.Books.Commands;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace Book.Infra.Data.Sql.Commands.MessageBus
{
    public class RabbitMqProducer : IRabbitMqProducer
    {
        private readonly string _hostName = "localhost";
        private readonly string _queueName = "book-events";


        //public void  SendMessageAsync<T>(T message)
        //{
        //    var factory = new ConnectionFactory() { HostName = _hostName };

        //    using var connection = factory.CreateConnection();
        //    using var channel = connection.CreateModel();

        //    channel.QueueDeclare(queue: _queueName,
        //                         durable: false,
        //                         exclusive: false,
        //                         autoDelete: false);

        //    var json = JsonSerializer.Serialize(message);
        //    var body = Encoding.UTF8.GetBytes(json);

        //    channel.BasicPublish(exchange: "",
        //                         routingKey: _queueName,
        //                         basicProperties: null,
        //                         body: body);
        //}

        public async Task SendMessageAsync<T>(T message)
        {
            var factory = new ConnectionFactory() { HostName = _hostName };

    
             using var connection = factory.CreateConnection();
             using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: _queueName,
                                 durable: true,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var json = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(json);

            channel.BasicPublish(exchange: "",
                                 routingKey: _queueName,
                                 basicProperties: null,
                                 body: body);

            await Task.CompletedTask; 
        }

    }
}
