using Microsoft.AspNetCore.Mvc;

namespace PortfolioService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PerformanceController : ControllerBase
    {
        private readonly PerformanceService _performanceService;

        public PerformanceController(PerformanceService performanceService)
        {
            _performanceService = performanceService;
        }

        [HttpGet]
        public IActionResult GetPerformanceHistory()
        {
            try
            {
                var history = _performanceService.GetAll();
                SplunkLogger.LogInfo("Fetched performance history successfully", HttpContext, new { Count = history.Count });
                return Ok(history);
            }
            catch (Exception ex)
            {
                SplunkLogger.LogError("Failed to fetch performance history", ex, HttpContext);
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}