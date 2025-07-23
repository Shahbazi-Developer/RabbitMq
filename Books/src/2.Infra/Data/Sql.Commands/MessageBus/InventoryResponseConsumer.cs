using Book.Core.Contracts.Books;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MobileView.Services;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace Book.Infrastructure.MessageBus
{
    public class InventoryResponseConsumer : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<InventoryResponseConsumer> _logger;
        private IConnection? _connection;
        private IModel? _channel;

        public InventoryResponseConsumer(IServiceProvider serviceProvider, ILogger<InventoryResponseConsumer> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
            InitializeRabbitMq();
        }

        private void InitializeRabbitMq()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.QueueDeclare(queue: "inventory-responses", durable: true, exclusive: false, autoDelete: false);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.Register(() =>
            {
                _channel?.Close();
                _connection?.Close();
            });

            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var json = Encoding.UTF8.GetString(body);

                WarehouseMobileCreatedEvent? response = null;
                try
                {
                    response = JsonSerializer.Deserialize<WarehouseMobileCreatedEvent>(json);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "خطا در دسیریالایز پیام پاسخ انبار");
                    // ممکن است پیام معیوب باشد، می‌توان این پیام را Dead Letter کرد یا ثبت نمود
                }

                if (response != null)
                {
                    using var scope = _serviceProvider.CreateScope();
                    var handler = scope.ServiceProvider.GetRequiredService<InventoryCheckResponseHandler>();
                    await handler.Handle(response);
                }

                _channel.BasicAck(ea.DeliveryTag, false);
            };

            _channel.BasicConsume(queue: "inventory-responses", autoAck: false, consumer: consumer);

            _logger.LogInformation("🚀 منتظر پیام‌های پاسخ انبار در صف inventory-responses هستیم...");

            return Task.CompletedTask;
        }

        public override void Dispose()
        {
            _channel?.Close();
            _connection?.Close();
            base.Dispose();
        }
    }
}
