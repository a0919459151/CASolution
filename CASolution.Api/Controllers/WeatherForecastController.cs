using CASolution.Api.Contracts;
using CASolution.Application.services.WeatherForecast;
using Microsoft.AspNetCore.Mvc;

namespace CASolution.Api.Controllers;

[Route("[controller]")]
public class WeatherForecastController : ApiController
{
    private readonly IWeatherForecastService _weatherForecastService;

    public WeatherForecastController(IWeatherForecastService weatherForecastService)
    {
        _weatherForecastService = weatherForecastService;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<IActionResult> GetWeatherForecast()
    {
        var results = await _weatherForecastService.GetWeatherForecast();

        return results.Match(
            results => Ok(MapToResponse(results)),
            errors => Problem(errors));
    }

    private static IEnumerable<GetWeatherForecastResponse> MapToResponse(IEnumerable<WeatherForecastResult> results)
    {
        return results.Select(x => new GetWeatherForecastResponse
        {
            Date = x.Date,
            TemperatureC = x.TemperatureC,
            TemperatureF = x.TemperatureF,
            Summary = x.Summary
        });
    }
}
