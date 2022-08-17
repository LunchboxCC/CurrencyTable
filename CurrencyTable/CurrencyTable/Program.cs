using CurrencyTable.Database;
using CurrencyTable.HttpClients;
using CurrencyTable.Interfaces;
using CurrencyTable.Models.DTOs;
using CurrencyTable.Models.Entities;
using CurrencyTable.Repositories;
using CurrencyTable.Services;
using CurrencyTable.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

ConfigureDb(builder);
ConfigureAutoMapper(builder.Services);
ConfigureServices(builder.Services);
ConfigureSwagger(builder);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpLogging();
app.UseRouting();
app.UseStaticFiles();
app.MapControllers();

app.Run();

static void ConfigureServices(IServiceCollection services)
{
    services.AddScoped<ICurrencyService, CurrencyService>();

    services.AddScoped<ICurrenciesRepository, CurrenciesRepository>();
    
    services.AddScoped<IApiDownloadCurrencyTable, ApiDownloadCurrencyTableErste>();
    
    services.AddTransient<IHttpClientService, HttpClientService>();

    services.AddScoped<IParamValidator, ParamValidator>();
    services.AddScoped<IValidator<Currency>, CurrencyValidator>();
    services.AddScoped<IValidator<CurrencyDTO>, CurrencyDTOValidator>();

    services.AddHttpClient();
}

static void ConfigureDb(WebApplicationBuilder builder)
{
    var connectionString = builder.Configuration.GetConnectionString("DevelopmentConnection");
    builder.Services.AddDbContext<ApplicationContext>(b => b.UseSqlServer(connectionString));
}

static void ConfigureAutoMapper(IServiceCollection services)
{
    services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
}

static void ConfigureSwagger(WebApplicationBuilder builder)
{
    builder.Services.AddSwaggerGen(options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "Currency tables",
            Description = "Interview homework"
        });

        var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
    }
    );
}

public partial class Program { }