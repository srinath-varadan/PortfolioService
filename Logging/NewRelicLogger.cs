using System.Net.Http.Headers;
using System.Text.Json;

namespace LogAggregatorService.Services
{
    public class NewRelicLogger
    {
        private readonly HttpClient _client;
        private readonly string _licenseKey;

        public NewRelicLogger(HttpClient client, IConfiguration config)
        {
            _client = client;
            _licenseKey = "22c9b04d4bb0d494b18d39914757e99eFFFFNRAL";
        }

        public void LogDetailedAsync(string controller, string method, string httpVerb, object payload, string message, string level = "info")
        {
            var logEntry = new[]
            {
                new
                {
                    message = message,
                    level = level,
                    timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(),
                    attributes = new
                    {
                        appName = "PortfolioService",
                        controller = controller,
                        method = method,
                        httpVerb = httpVerb,
                        payload = payload, // ⚡ serialized payload
                        env = "POC" // or "Production" later
                    }
                }
            };

            var request = new HttpRequestMessage(HttpMethod.Post, "https://log-api.newrelic.com/log/v1")
            {
                Content = new StringContent(JsonSerializer.Serialize(logEntry), System.Text.Encoding.UTF8, "application/json")
            };
            request.Headers.Add("Api-Key", _licenseKey);

            var response = Task.Run(()=>_client.SendAsync(request)).Result; 

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"New Relic Log failed: {response.StatusCode}");
            }
        }
    }
}