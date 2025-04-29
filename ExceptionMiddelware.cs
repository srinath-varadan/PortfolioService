using System.Net;
using System.Text.Json;
using LogAggregatorService.Services;

public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly NewRelicLogger _logger;

    public GlobalExceptionMiddleware(RequestDelegate next, NewRelicLogger logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }

        // Handle 404 (Not Found) for wrong routes
        if (context.Response.StatusCode == (int)HttpStatusCode.NotFound)
        {
            _logger.LogDetailedAsync(
                controller: "Global",
                method: "InvokeAsync",
                httpVerb: context.Request.Method,
                payload: null,
                message: $"Route not found: {context.Request.Path}",
                level: "warning"
            );
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        // Log the exception to New Relic
        _logger.LogDetailedAsync(
            controller: "Global",
            method: "InvokeAsync",
            httpVerb: context.Request.Method,
            payload: null,
            message: exception.Message,
            level: "error"
        );

        // Return a generic error response
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var response = new
        {
            StatusCode = context.Response.StatusCode,
            Message = "An unexpected error occurred. Please try again later."
        };

        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}