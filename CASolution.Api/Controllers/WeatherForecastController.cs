using CASolution.Api.Contracts;
using CASolution.Application.services.WeatherForecast;
using CASolution.Domain.Entities;
using Mapster;
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
            results => Ok(results.Adapt<IEnumerable<GetWeatherForecastResponse>>()),
            errors => Problem(errors));
    }

    [HttpPost(Name = "UpsertWeatherForecast")]
    public async Task<IActionResult> UpsertWeatherForecast(UpsertWeatherForecastRequest request)
    {
        var result = await _weatherForecastService.UpsertWeatherForecast(request.Adapt<WeatherForecast>());
        return result.Match(
            result => Ok(result),
            errors => Problem(errors));
    }
}
