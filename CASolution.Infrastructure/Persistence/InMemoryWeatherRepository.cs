using CASolution.Application.Interfaces.Persistence;
using CASolution.Domain.Entities;

namespace CASolution.Infrastructure.Persistence;

public class InMemoryWeatherRepository : IWeatherRepository
{
    private static readonly List<WeatherForecast> _weatherForecasts = new()
    {
        new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-5)),
            TemperatureC = 25,
        },
        new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-4)),
            TemperatureC = 30,
        },
        new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-3)),
            TemperatureC = 35,
        },
        new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-2)),
            TemperatureC = 40,
        },
        new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-1)),
            TemperatureC = 45,
        },
    };

    public Task<IEnumerable<WeatherForecast>> GetWeatherForecast()
    {
        return Task.FromResult(_weatherForecasts.AsEnumerable());
    }

    public Task<WeatherForecast?> GetWeatherForecastByDate(DateOnly date)
    {
        var weatherForecast = _weatherForecasts.Find(w => w.Date == date);
        if (weatherForecast is null)
        {
            return Task.FromResult<WeatherForecast?>(null);
        }
        return Task.FromResult<WeatherForecast?>(weatherForecast);
    }

    public Task<WeatherForecast> CreateWeatherForecast(WeatherForecast weatherForecast)
    {
        _weatherForecasts.Add(weatherForecast);
        return Task.FromResult(weatherForecast);
    }

    public Task<WeatherForecast> UpdateWeatherForecast(WeatherForecast weatherForecast)
    {
        var index = _weatherForecasts.FindIndex(w => w.Date == weatherForecast.Date);
        _weatherForecasts[index] = weatherForecast;
        return Task.FromResult(weatherForecast);
    }
}
