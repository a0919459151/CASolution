using WeatherForecastEntity = CASolution.Domain.Entities.WeatherForecast; // tyoe alias 

namespace CASolution.Application.Interfaces.Persistence;

public interface IWeatherRepository
{
    Task<IEnumerable<WeatherForecastEntity>> GetWeatherForecastAsync();
}
