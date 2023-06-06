using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    private static List<WeatherForecast> listWeatherForecast = new List<WeatherForecast>();

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;

        if (listWeatherForecast == null || !listWeatherForecast.Any())
        {
            listWeatherForecast = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToList();
        }
    }

    [HttpGet(Name = "GetWeatherForecast")]
    //[Route("[action]")] //* Es el nombre de la función
    //[Route("Get/weatherforecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return listWeatherForecast;
    }

    [HttpPost]
    public IActionResult Post(WeatherForecast weatherForecast)
    {
        listWeatherForecast.Add(weatherForecast);
        return Ok("Added weather forecast to list");
    }

    [HttpDelete("{index}")]
    public IActionResult Delete(int index)
    {
        if (index < 0 || index >= listWeatherForecast.Count)
        {
            return BadRequest("Index out of bounds");
        }
        listWeatherForecast.RemoveAt(index);
        return Ok("Deleted weather forecast from list");
    }
}
