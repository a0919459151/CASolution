using CASolution.Application.Serivcies.WeatherForecast;
using CASolution.Domain.Enities;

namespace CASolution.Infrastructure.Persistence;

public interface IWeatherRepository
{
    Task<IEnumerable<WeatherForecast>> GetWeatherForecastAsync();
}
