using Serilog;
using Serilog.Sinks.Splunk;
using Microsoft.OpenApi.Models;
using Prometheus;
using LogAggregatorService.Services;
using Microsoft.AspNetCore.HttpOverrides;


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
builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders = 
        ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
    options.KnownNetworks.Clear(); // Clear default to allow any network
    options.KnownProxies.Clear();
});



// Regular service setup
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Portfolio API", Version = "v1" });
});

builder.Services.AddHttpClient();
builder.Services.AddSingleton<NewRelicLogger>();


builder.Services.AddSingleton<AssetService>();
builder.Services.AddSingleton<HoldingService>();
builder.Services.AddSingleton<PerformanceService>();

var app = builder.Build();

app.UseMiddleware<GlobalExceptionMiddleware>();
app.UseForwardedHeaders();
app.UseRouting();

app.UseCors();

app.UseHttpMetrics(); // Collect HTTP request metrics

// Add Prometheus metrics endpoint
app.MapMetrics(); // Exposes metrics at /metrics


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