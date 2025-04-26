using Microsoft.AspNetCore.Mvc;
using PortfolioService.Api.Logging;

[ApiController]
[Route("api/performance")]
public class PerformanceController : ControllerBase
{
    private readonly PerformanceService _service;

    public PerformanceController(PerformanceService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        SplunkLogger.LogInformation("Fetching performance history");
        return Ok(_service.GetAll());
    }
}