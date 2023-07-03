using WeatherForecastEntity = CASolution.Domain.Entities.WeatherForecast; // type alias 

namespace CASolution.Application.Interfaces.Persistence;

public interface IWeatherRepository
{
    Task<IEnumerable<WeatherForecastEntity>> GetWeatherForecast();
    Task<WeatherForecastEntity?> GetWeatherForecastByDate(DateOnly date);
    Task<WeatherForecastEntity> CreateWeatherForecast(WeatherForecastEntity weatherForecast);
    Task<WeatherForecastEntity> UpdateWeatherForecast(WeatherForecastEntity weatherForecast);
}
