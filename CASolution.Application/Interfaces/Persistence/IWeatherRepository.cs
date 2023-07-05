using WeatherForecastEntity = CASolution.Domain.Entities.WeatherForecast; // type alias 

namespace CASolution.Application.Interfaces.Persistence;

public interface IWeatherRepository
{
    bool IsExistWeatherForecastByDate(DateOnly date);
    Task<IEnumerable<WeatherForecastEntity>> GetWeatherForecast();
    Task<WeatherForecastEntity?> GetWeatherForecastByDate(DateOnly date);

    void CreateWeatherForecast(WeatherForecastEntity weatherForecast);
    void UpdateWeatherForecast(WeatherForecastEntity weatherForecast);
}
