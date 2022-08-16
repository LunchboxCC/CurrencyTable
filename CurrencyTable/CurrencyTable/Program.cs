using CurrencyTable.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

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
    services.AddHttpClient();
    //services.AddSingleton<IConfiguration>();
    //services.AddScoped<ApplicationContext>();
}

static void ConfigureDb(WebApplicationBuilder builder)
{
    var connectionString = builder.Configuration.GetConnectionString("DevelopmentConnection");
    builder.Services.AddDbContext<ApplicationContext>(b => b.UseSqlServer(connectionString));
}