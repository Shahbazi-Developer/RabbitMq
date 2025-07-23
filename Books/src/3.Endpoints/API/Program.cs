using Book.Core.Contracts.Books.Commands;
using Book.Endpoints.API.Extentions;
using Book.Infrastructure.MessageBus;
using MobileView.Services;
using Zamin.Extensions.DependencyInjection;
using Zamin.Utilities.SerilogRegistration.Extensions;

SerilogExtensions.RunWithSerilogExceptionHandling(() =>
{
    var builder = WebApplication.CreateBuilder(args);

    // 🔧 ثبت RabbitMQ Producer
    builder.Services.AddSingleton<IRabbitMqProducer, RabbitMqProducer>();

    // ✅ افزودن هندلر و Consumer برای پاسخ انبار
    builder.Services.AddScoped<InventoryCheckResponseHandler>();
    builder.Services.AddHostedService<InventoryResponseConsumer>();

    var app = builder.AddZaminSerilog(o =>
    {
        o.ApplicationName = builder.Configuration.GetValue<string>("ApplicationName");
        o.ServiceId = builder.Configuration.GetValue<string>("ServiceId");
        o.ServiceName = builder.Configuration.GetValue<string>("ServiceName");
        o.ServiceVersion = builder.Configuration.GetValue<string>("ServiceVersion");
    })
    .ConfigureServices()
    .ConfigurePipeline();

    app.Run();
});
