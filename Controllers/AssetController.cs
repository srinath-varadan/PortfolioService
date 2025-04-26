
using Microsoft.AspNetCore.Mvc;
using PortfolioService.Api.Logging;

[ApiController]
[Route("api/assets")]
public class AssetController : ControllerBase
{
    private readonly AssetService _service;

    public AssetController(AssetService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        SplunkLogger.LogInformation("Fetching all assets");
        return Ok(_service.GetAll());
    }

    [HttpPost]
    public IActionResult Post([FromBody] Asset asset)
    {
        _service.Add(asset);
        SplunkLogger.LogInformation("Asset created", asset);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Asset asset)
    {
        _service.Update(id, asset);
        SplunkLogger.LogInformation("Asset updated", new { Id = id, UpdatedAsset = asset });
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _service.Delete(id);
        SplunkLogger.LogInformation("Asset deleted", new { Id = id });
        return Ok();
    }
}