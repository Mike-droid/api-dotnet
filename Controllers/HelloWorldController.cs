using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloWorldController:  ControllerBase
{
    IHelloWorldService helloWorldService;

    TareasContext dbContext;

    private readonly ILogger<HelloWorldController> _logger;

    public HelloWorldController(IHelloWorldService helloWorld, ILogger<HelloWorldController> logger, TareasContext db)
    {
        helloWorldService = helloWorld;
        _logger = logger;
        dbContext = db;
    }

    [HttpGet]
    public IActionResult Get()
    {
        _logger.LogInformation("This is the log for hello world!");
        return Ok(helloWorldService.GetHelloWorld());
    }

    [HttpGet]
    [Route("createdb")]
    public IActionResult CreateDatabase()
    {
        dbContext.Database.EnsureCreated();
        return Ok("Database created successfully!");
    }
}
