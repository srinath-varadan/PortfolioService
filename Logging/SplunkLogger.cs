using Serilog;
using Microsoft.AspNetCore.Http;

public static class SplunkLogger
{
    public static void LogInfo(string message, HttpContext context = null, object additionalData = null)
    {
        Log.Information("{@LogEvent}", CreateLogPayload("Information", message, context, additionalData));
    }

    public static void LogWarning(string message, HttpContext context = null, object additionalData = null)
    {
        Log.Warning("{@LogEvent}", CreateLogPayload("Warning", message, context, additionalData));
    }

    public static void LogError(string message, Exception ex = null, HttpContext context = null, object additionalData = null)
    {
        Log.Error(ex, "{@LogEvent}", CreateLogPayload("Error", message, context, additionalData));
    }

    private static object CreateLogPayload(string level, string message, HttpContext context, object additionalData)
    {
        return new
        {
            Timestamp = DateTime.UtcNow,
            Level = level,
            Message = message,
            Origin = context?.Request.Headers["Origin"].FirstOrDefault(),
            UserAgent = context?.Request.Headers["User-Agent"].FirstOrDefault(),
            Host = context?.Request.Host.ToString(),
            Path = context?.Request.Path.ToString(),
            QueryString = context?.Request.QueryString.ToString(),
            IpAddress = context?.Connection.RemoteIpAddress?.ToString(),
            UserId = context?.User?.Identity?.IsAuthenticated == true ? context.User.Identity.Name : "Anonymous",
            AdditionalData = additionalData
        };
    }
}