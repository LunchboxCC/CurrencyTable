using CurrencyTable.Database;
using CurrencyTable.HttpClients;
using CurrencyTable.Interfaces;
using CurrencyTable.Repositories;
using CurrencyTable.Services;
using CurrencyTable.Validators;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

ConfigureDb(builder);
ConfigureServices(builder.Services);

var app = builder.Build();

app.UseHttpLogging();
app.UseRouting();
app.UseStaticFiles();
app.MapControllers();

app.Run();

static void ConfigureServices(IServiceCollection services)
{
    services.AddScoped<ICurrencyValidator, CurrencyValidator>();
    services.AddScoped<ICurrencyService, CurrencyService>();
    services.AddScoped<ICurrenciesRepository, CurrenciesRepository>();
    services.AddScoped<ICurrencyDownloadService, CurrencyDownloadServiceErste>();
    services.AddTransient<IHttpClientService, HttpClientService>();

    services.AddHttpClient();
    //services.AddSingleton<IConfiguration>();
    //services.AddScoped<ApplicationContext>();
}

static void ConfigureDb(WebApplicationBuilder builder)
{
    var connectionString = builder.Configuration.GetConnectionString("DevelopmentConnection");
    builder.Services.AddDbContext<ApplicationContext>(b => b.UseSqlServer(connectionString));
}