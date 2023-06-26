using ErrorOr;

namespace CASolution.Application.services.WeatherForecast;

public interface IWeatherForecastService
{
    Task<ErrorOr<IEnumerable<WeatherForecastResult>>> GetWeatherForecast();
}