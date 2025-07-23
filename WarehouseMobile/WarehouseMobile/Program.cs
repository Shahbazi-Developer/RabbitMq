using Microsoft.EntityFrameworkCore;
using MobileView.Datas;
using MobileView.Hubs;
using MobileView.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddRazorPages();
builder.Services.AddSingleton<InBookWarehouse>();
builder.Services.AddHostedService<RabbitMqService>();

builder.Services.AddSignalR();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BookViewerConnectionString")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseStaticFiles();

//app.MapStaticAssets();

app.MapRazorPages();
   //.WithStaticAssets();

app.MapHub<BookWarehouseHub>("/warehouseMobileHub");

app.Run();
