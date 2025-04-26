using Serilog;
using Serilog.Sinks.Splunk;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// 🔥 Configure Serilog
var splunkUrl = builder.Configuration["Splunk:CollectorUrl"];
var splunkToken = builder.Configuration["Splunk:Token"];
Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.EventCollector(
        splunkHost: splunkUrl,
        eventCollectorToken: splunkToken,
        sourceType: "json",
        restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information,
        messageHandler: new HttpClientHandler
    {
        ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
    }
    )
    .CreateLogger();

builder.Host.UseSerilog();


// Regular service setup
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Portfolio API", Version = "v1" });
});


builder.Services.AddSingleton<AssetService>();
builder.Services.AddSingleton<HoldingService>();
builder.Services.AddSingleton<PerformanceService>();

var app = builder.Build();


app.UseRouting();

app.UseCors();


if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Portfolio API v1");
    });
}




app.MapControllers();

app.MapGet("/health", () => Results.Ok("Healthy"));

app.Run();