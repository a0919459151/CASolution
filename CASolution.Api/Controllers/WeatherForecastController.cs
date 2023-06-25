using CASolution.Api.Contracts;
using CASolution.Application.Interfaces.WeatherForecast;
using Microsoft.AspNetCore.Mvc;

namespace CASolution.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IWeatherForecastSerivce _weatherForecastSerivce;

    public WeatherForecastController(IWeatherForecastSerivce weatherForecastSerivce)
    {
        _weatherForecastSerivce = weatherForecastSerivce;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<IActionResult> GetWeatherForecast()
    {
        var result = await _weatherForecastSerivce.GetWeatherForecast();

        var response = result.Select(x => new GetWeatherForecastResponse
        {
            Date = x.Date,
            TemperatureC = x.TemperatureC,
            TemperatureF = x.TemperatureF,
            Summary = x.Summary
        });

        return Ok(response);
    }
}
