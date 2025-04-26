using Microsoft.AspNetCore.Mvc;
using PortfolioService.Api.Logging;

[ApiController]
[Route("api/holdings")]
public class HoldingController : ControllerBase
{
    private readonly HoldingService _service;
  public HoldingController(HoldingService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        SplunkLogger.LogInformation("Fetching all holdings");
        return Ok(_service.GetAll());
    }

    [HttpPost]
    public IActionResult Post([FromBody] Holding holding)
    {
        _service.Add(holding);
        SplunkLogger.LogInformation("Holding created", holding);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Holding holding)
    {
        _service.Update(id, holding);
        SplunkLogger.LogInformation("Holding updated", new { Id = id, UpdatedHolding = holding });
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _service.Delete(id);
        SplunkLogger.LogInformation("Holding deleted", new { Id = id });
        return Ok();
    }
}