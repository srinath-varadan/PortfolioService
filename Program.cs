using Serilog;
using Serilog.Sinks.Splunk;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

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
var allowedOrigins = new[] {
    "https://srinath-varadan.github.io"
};

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowGitHubPages", policy =>
        policy.WithOrigins(allowedOrigins)
              .AllowAnyHeader()
              .AllowAnyMethod());
});


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

if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Portfolio API v1");
    });
}

app.UseCors("AllowGitHubPages");

app.MapControllers();

app.MapGet("/health", () => Results.Ok("Healthy"));

app.Run();