using CASolution.Api.Contracts;
using CASolution.Application.Interfaces.WeatherForecast;
using CASolution.Application.services.WeatherForecast;
using Microsoft.AspNetCore.Mvc;

namespace CASolution.Api.Controllers;

[Route("[controller]")]
public class WeatherForecastController : ApiController
{
    private readonly IWeatherForecastSerivce _weatherForecastSerivce;

    public WeatherForecastController(IWeatherForecastSerivce weatherForecastSerivce)
    {
        _weatherForecastSerivce = weatherForecastSerivce;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<IActionResult> GetWeatherForecast()
    {
        var results = await _weatherForecastSerivce.GetWeatherForecast();

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
