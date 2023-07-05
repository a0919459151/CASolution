using ErrorOr;
using WeatherForecastEntity = CASolution.Domain.Entities.WeatherForecast;

namespace CASolution.Application.services.WeatherForecast;

public interface IWeatherForecastService
{
    Task<ErrorOr<IEnumerable<WeatherForecastResult>>> GetWeatherForecast();
    Task<ErrorOr<WeatherForecastResult>> CreateWeatherForecast(WeatherForecastEntity weatherForecast);
    Task<ErrorOr<WeatherForecastResult>> UpdateWeatherForecast(WeatherForecastEntity weatherForecast);
}
