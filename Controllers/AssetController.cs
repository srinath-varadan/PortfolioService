using LogAggregatorService.Services;
using Microsoft.AspNetCore.Mvc;
namespace PortfolioService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssetController : ControllerBase
    {
        private readonly AssetService _assetService;
        private readonly NewRelicLogger _logger;

        public AssetController(AssetService assetService,NewRelicLogger logger)
        {
            _logger = logger;
            _assetService = assetService;
        }

        [HttpGet]
        public IActionResult GetAllAssets()
        {
            try
            {
                var assets = _assetService.GetAssets();
                 _logger.LogDetailedAsync(
            controller: "AssetController",
            method: nameof(GetAllAssets),
            httpVerb: HttpContext.Request.Method,
            payload: null,
            message: "Asset fetched Successfully",
            level: "info"
        );

                return Ok(assets);
            }
            catch (Exception ex)
            {
                 _logger.LogDetailedAsync(
            controller: "AssetController",
            method: nameof(GetAllAssets),
            httpVerb: HttpContext.Request.Method,
            payload: null,
            message: $"Asset fetch Failed: {ex.Message}",
            level: "error"
        );
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost]
        public IActionResult AddAsset([FromBody] Asset asset)
        {
            try
            {
                _assetService.AddAsset(asset);
                _logger.LogDetailedAsync(
            controller: "AssetController",
            method: nameof(AddAsset),
            httpVerb: HttpContext.Request.Method,
            payload: asset,
            message: "Asset Created Successfully",
            level: "info"
        );
                return CreatedAtAction(nameof(GetAllAssets), new { id = asset.Id }, asset);
            }
            catch (Exception ex)
            {
                _logger.LogDetailedAsync(
            controller: "AssetController",
            method: nameof(AddAsset),
            httpVerb: HttpContext.Request.Method,
            payload: asset,
            message: $"Asset Creation Failed: {ex.Message}",
            level: "error"
        );
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAsset(int id, [FromBody] Asset asset)
        {
            try
            {
                _assetService.UpdateAsset(id, asset);
                _logger.LogDetailedAsync(
            controller: "AssetController",
            method: nameof(UpdateAsset),
            httpVerb: HttpContext.Request.Method,
            payload: asset,
            message: "Asset update Successfully",
            level: "info"
        );
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogDetailedAsync(
            controller: "AssetController",
            method: nameof(UpdateAsset),
            httpVerb: HttpContext.Request.Method,
            payload: asset,
            message: $"Asset update Failed: {ex.Message}",
            level: "error"
        );
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAsset(int id)
        {
            try
            {
                _assetService.DeleteAsset(id);
                   _logger.LogDetailedAsync(
            controller: "AssetController",
            method: nameof(DeleteAsset),
            httpVerb: HttpContext.Request.Method,
            payload: id,
            message: "Asset deleted Successfully",
            level: "info"
        );
                return NoContent();
            }
            catch (Exception ex)
            {
                  _logger.LogDetailedAsync(
            controller: "AssetController",
            method: nameof(DeleteAsset),
            httpVerb: HttpContext.Request.Method,
            payload: id,
            message: $"Asset delete Failed: {ex.Message}",
            level: "error"
        );
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}