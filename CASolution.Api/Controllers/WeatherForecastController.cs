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

    [HttpPost(Name = "CreateWeatherForecast")]
    public async Task<IActionResult> CreateWeatherForecast(CreateWeatherForecastRequest request)
    {
        var results = await _weatherForecastService.CreateWeatherForecast(request.Adapt<WeatherForecast>());
        return results.Match(
           results => Ok(results.Adapt<CreateWeatherForecastResponse>()),
           errors => Problem(errors));
    }

    [HttpPut(Name = "UpdateWeatherForecast")]
    public async Task<IActionResult> UpdateWeatherForecast(UpdateWeatherForecastRequest request)
    {
        var results = await _weatherForecastService.UpdateWeatherForecast(request.Adapt<WeatherForecast>());
        return results.Match(
            results => Ok(results.Adapt<UpdateWeatherForecastResponse>()),
            errors => Problem(errors));
    }
}
