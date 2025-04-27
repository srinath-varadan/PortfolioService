using LogAggregatorService.Services;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PerformanceController : ControllerBase
    {
        private readonly PerformanceService _performanceService;
          private readonly NewRelicLogger _logger;

        public PerformanceController(PerformanceService performanceService, NewRelicLogger logger)
        {
            
            _logger = logger;
            _performanceService = performanceService;
        }

        [HttpGet]
        public IActionResult GetPerformanceHistory()
        {
            try
            {
                var history = _performanceService.GetAll();
                _logger.LogDetailedAsync(
                    controller: nameof(PerformanceController),
                    method: nameof(GetPerformanceHistory),
                    httpVerb: HttpContext.Request.Method,
                    payload: new { Count = history.Count },
                    message: "Fetched performance history successfully",
                    level: "info"
                );
                return Ok(history);
            }
            catch (Exception ex)
            {   
                _logger.LogDetailedAsync(
                    controller: nameof(PerformanceController),
                    method: nameof(GetPerformanceHistory),
                    httpVerb: HttpContext.Request.Method,
                    payload: null,
                    message: $"Failed to fetch performance history: {ex.Message}",
                    level: "error"
                );
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}