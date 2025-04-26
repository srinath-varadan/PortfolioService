using Microsoft.AspNetCore.Mvc;

namespace PortfolioService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HoldingController : ControllerBase
    {
        private readonly HoldingService _holdingService;

        public HoldingController(HoldingService holdingService)
        {
            _holdingService = holdingService;
        }

        [HttpGet]
        public IActionResult GetAllHoldings()
        {
            try
            {
                var holdings = _holdingService.GetHoldings();
                SplunkLogger.LogInfo("Fetched holdings successfully", HttpContext, new { Count = holdings.Count });
                return Ok(holdings);
            }
            catch (Exception ex)
            {
                SplunkLogger.LogError("Failed to fetch holdings", ex, HttpContext);
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost]
        public IActionResult AddHolding([FromBody] Holding holding)
        {
            try
            {
                _holdingService.AddHolding(holding);
                SplunkLogger.LogInfo("Added new holding successfully", HttpContext, new { Holding = holding });
                return CreatedAtAction(nameof(GetAllHoldings), new { id = holding.Id }, holding);
            }
            catch (Exception ex)
            {
                SplunkLogger.LogError("Failed to add holding", ex, HttpContext);
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateHolding(int id, [FromBody] Holding holding)
        {
            try
            {
                _holdingService.UpdateHolding(id, holding);
                SplunkLogger.LogInfo("Updated holding successfully", HttpContext, new { HoldingId = id });
                return NoContent();
            }
            catch (Exception ex)
            {
                SplunkLogger.LogError("Failed to update holding", ex, HttpContext);
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteHolding(int id)
        {
            try
            {
                _holdingService.DeleteHolding(id);
                SplunkLogger.LogInfo("Deleted holding successfully", HttpContext, new { HoldingId = id });
                return NoContent();
            }
            catch (Exception ex)
            {
                SplunkLogger.LogError("Failed to delete holding", ex, HttpContext);
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}