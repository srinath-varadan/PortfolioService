using Microsoft.AspNetCore.Mvc;
using LogAggregatorService.Services; // Assuming NewRelicLogger is here

namespace PortfolioService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HoldingController : ControllerBase
    {
        private readonly HoldingService _holdingService;
        private readonly NewRelicLogger _logger;

        public HoldingController(HoldingService holdingService, NewRelicLogger logger)
        {
            _holdingService = holdingService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAllHoldings()
        {
            try
            {
                var holdings = _holdingService.GetHoldings();
                 _logger.LogDetailedAsync(
                    controller: nameof(HoldingController),
                    method: nameof(GetAllHoldings),
                    httpVerb: HttpContext.Request.Method,
                    payload: new { Count = holdings.Count },
                    message: "Fetched holdings successfully",
                    level: "info"
                );
                return Ok(holdings);
            }
            catch (Exception ex)
            {
                 _logger.LogDetailedAsync(
                    controller: nameof(HoldingController),
                    method: nameof(GetAllHoldings),
                    httpVerb: HttpContext.Request.Method,
                    payload: null,
                    message: $"Failed to fetch holdings: {ex.Message}",
                    level: "error"
                );
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost]
        public IActionResult AddHolding([FromBody] Holding holding)
        {
            try
            {
                _holdingService.AddHolding(holding);
                 _logger.LogDetailedAsync(
                    controller: nameof(HoldingController),
                    method: nameof(AddHolding),
                    httpVerb: HttpContext.Request.Method,
                    payload: holding,
                    message: "Added new holding successfully",
                    level: "info"
                );
                return CreatedAtAction(nameof(GetAllHoldings), new { id = holding.Id }, holding);
            }
            catch (Exception ex)
            {
                 _logger.LogDetailedAsync(
                    controller: nameof(HoldingController),
                    method: nameof(AddHolding),
                    httpVerb: HttpContext.Request.Method,
                    payload: holding,
                    message: $"Failed to add holding: {ex.Message}",
                    level: "error"
                );
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateHolding(int id, [FromBody] Holding holding)
        {
            try
            {
                _holdingService.UpdateHolding(id, holding);
                 _logger.LogDetailedAsync(
                    controller: nameof(HoldingController),
                    method: nameof(UpdateHolding),
                    httpVerb: HttpContext.Request.Method,
                    payload: new { HoldingId = id, UpdatedHolding = holding },
                    message: "Updated holding successfully",
                    level: "info"
                );
                return NoContent();
            }
            catch (Exception ex)
            {
                 _logger.LogDetailedAsync(
                    controller: nameof(HoldingController),
                    method: nameof(UpdateHolding),
                    httpVerb: HttpContext.Request.Method,
                    payload: new { HoldingId = id, Payload = holding },
                    message: $"Failed to update holding: {ex.Message}",
                    level: "error"
                );
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteHolding(int id)
        {
            try
            {
                _holdingService.DeleteHolding(id);
                 _logger.LogDetailedAsync(
                    controller: nameof(HoldingController),
                    method: nameof(DeleteHolding),
                    httpVerb: HttpContext.Request.Method,
                    payload: new { HoldingId = id },
                    message: "Deleted holding successfully",
                    level: "info"
                );
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogDetailedAsync(
                    controller: nameof(HoldingController),
                    method: nameof(DeleteHolding),
                    httpVerb: HttpContext.Request.Method,
                    payload: new { HoldingId = id },
                    message: $"Failed to delete holding: {ex.Message}",
                    level: "error"
                );
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}