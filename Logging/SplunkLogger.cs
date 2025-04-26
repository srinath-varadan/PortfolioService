using Serilog;

namespace PortfolioService.Api.Logging
{
    public static class SplunkLogger
    {
        public static void LogInformation(string message, object context = null)
        {
            if (context != null)
                Log.Information("{Message} {@Context}", message, context);
            else
                Log.Information("{Message}", message);
        }

        public static void LogError(string message, Exception ex = null)
        {
            if (ex != null)
                Log.Error(ex, "{Message}", message);
            else
                Log.Error("{Message}", message);
        }
    }
}