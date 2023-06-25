using CASolution.Domain.Enities;

namespace CASolution.Infrastructure.Persistence;

public class WeatherRepository : IWeatherRepository
{
    public Task<IEnumerable<WeatherForecast>> GetWeatherForecastAsync()
    {
        return Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
        }));
    }
}
