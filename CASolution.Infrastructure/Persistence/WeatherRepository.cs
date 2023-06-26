using CASolution.Application.Interfaces.Persistence;
using CASolution.Domain.Entities;

namespace CASolution.Infrastructure.Persistence;

public class WeatherRepository : IWeatherRepository
{
    public Task<IEnumerable<WeatherForecast>> GetWeatherForecastAsync()
    {
        // 30% chance of return empty
        if (Random.Shared.Next(0, 10) < 3)
        {
            return Task.FromResult(Enumerable.Empty<WeatherForecast>());
        }

        return Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
        }));
    }
}
