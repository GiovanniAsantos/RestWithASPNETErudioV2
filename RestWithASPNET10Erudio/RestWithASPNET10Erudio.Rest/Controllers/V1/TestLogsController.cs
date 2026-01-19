using Microsoft.AspNetCore.Mvc;

namespace RestWithASPNET10Erudio.Rest.Controllers.V1;

[ApiController]
[Route("api/[controller]/v1")]
public class TestLogsController :ControllerBase
{
    private readonly ILogger<TestLogsController> _logger;
    
    public TestLogsController(ILogger<TestLogsController> logger)
    {
        _logger = logger;
    }
    
    [HttpGet]
    public IActionResult LogTest()
    {
        _logger.LogTrace("This is a test log message from TestLogsController.");
        _logger.LogDebug("This is a debug log message from TestLogsController.");
        _logger.LogInformation("This is an information log message from TestLogsController.");
        _logger.LogWarning("This is a warning log message from TestLogsController.");
        _logger.LogError("This is an error log message from TestLogsController.");
        _logger.LogCritical("This is a critical log message from TestLogsController.");
        return Ok("Log test message sent to console.");
    }
}