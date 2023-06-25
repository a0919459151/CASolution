using CASolution.Application.Serivcies.WeatherForecast;

namespace CASolution.Application.Interfaces.WeatherForecast;

public interface IWeatherForecastSerivce
{
    Task<IEnumerable<WeatherForecastResult>> GetWeatherForecast();
}