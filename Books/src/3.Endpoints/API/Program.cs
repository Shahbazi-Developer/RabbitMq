using Book.Core.ApplicationService.Books.Commands.ReqBooks;
using Book.Core.Contracts.Books.Commands;
using Book.Endpoints.API.Extentions;
using Book.Infra.Data.Sql.Commands.MessageBus;
using Zamin.Extensions.DependencyInjection;
using Zamin.Utilities.SerilogRegistration.Extensions;

SerilogExtensions.RunWithSerilogExceptionHandling(() =>
{
    var builder = WebApplication.CreateBuilder(args);


    builder.Services.AddSingleton<IRabbitMqProducer, RabbitMqProducer>();


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
