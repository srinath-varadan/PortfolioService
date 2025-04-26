using Microsoft.AspNetCore.Mvc;
namespace PortfolioService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssetController : ControllerBase
    {
        private readonly AssetService _assetService;

        public AssetController(AssetService assetService)
        {
            _assetService = assetService;
        }

        [HttpGet]
        public IActionResult GetAllAssets()
        {
            try
            {
                var assets = _assetService.GetAssets();
                SplunkLogger.LogInfo("Fetched assets successfully", HttpContext, new { Count = assets.Count });
                return Ok(assets);
            }
            catch (Exception ex)
            {
                SplunkLogger.LogError("Failed to fetch assets", ex, HttpContext);
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost]
        public IActionResult AddAsset([FromBody] Asset asset)
        {
            try
            {
                _assetService.AddAsset(asset);
                SplunkLogger.LogInfo("Added new asset successfully", HttpContext, new { Asset = asset });
                return CreatedAtAction(nameof(GetAllAssets), new { id = asset.Id }, asset);
            }
            catch (Exception ex)
            {
                SplunkLogger.LogError("Failed to add asset", ex, HttpContext);
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAsset(int id, [FromBody] Asset asset)
        {
            try
            {
                _assetService.UpdateAsset(id, asset);
                SplunkLogger.LogInfo("Updated asset successfully", HttpContext, new { AssetId = id });
                return NoContent();
            }
            catch (Exception ex)
            {
                SplunkLogger.LogError("Failed to update asset", ex, HttpContext);
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAsset(int id)
        {
            try
            {
                _assetService.DeleteAsset(id);
                SplunkLogger.LogInfo("Deleted asset successfully", HttpContext, new { AssetId = id });
                return NoContent();
            }
            catch (Exception ex)
            {
                SplunkLogger.LogError("Failed to delete asset", ex, HttpContext);
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}