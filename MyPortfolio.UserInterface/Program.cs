using MyPortfolio.Repositories.Implementation;
using MyPortfolio.Repositories.Interfaces;
using MyPortfolio.Services;
using MyPortfolio.Services.Implementation;
using MyPortfolio.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRepository();
builder.Services.AddScoped<ITradeService, TradeService>();
builder.Services.AddScoped<IPerformanceService, PerformanceService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
}

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
