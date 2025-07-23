using Microsoft.AspNetCore.SignalR;
using MobileView.Datas;
using MobileView.Hubs;
using MobileView.Models;
using MobileView.Services;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

public class RabbitMqService : BackgroundService
{
    private readonly InWarehouseMobile _store;
    private readonly IHubContext<WarehouseMobileHub> _hub;
    private readonly IServiceScopeFactory _scopeFactory;

    public RabbitMqService(InWarehouseMobile store, IHubContext<WarehouseMobileHub> hub, IServiceScopeFactory scopeFactory)
    {
        _store = store;
        _hub = hub;
        _scopeFactory = scopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var factory = new ConnectionFactory { HostName = "localhost" ,Port = 5672 };

        var connection = factory.CreateConnection();
        var channel = connection.CreateModel();

        channel.QueueDeclare(queue: "book-events", durable: true, exclusive: false, autoDelete: false);

        var consumer = new EventingBasicConsumer(channel);

        consumer.Received += async (model, ea) =>
        {
            var json = Encoding.UTF8.GetString(ea.Body.ToArray());
            var message = JsonSerializer.Deserialize<WarehouseMobileCreatedEvent>(json);

            if (message is not null)
            {
                _store.Add(message);

                using var scope = _scopeFactory.CreateScope();
                var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                var entity = new WarehouseMobileCreatedEvent
                {
                    BookId = message.BookId,
                    Title = message.Title,
                    Author = message.Author,
                    CreationDate = message.CreationDate,
                };

                db.Warehouse.Add(entity);
                await db.SaveChangesAsync();

                await _hub.Clients.All.SendAsync("ReceiveWarehouseMobile", message);
            }
        };

        channel.BasicConsume(queue: "book-events", autoAck: true, consumer: consumer);

        await Task.Delay(Timeout.Infinite, stoppingToken); 
    }

}
