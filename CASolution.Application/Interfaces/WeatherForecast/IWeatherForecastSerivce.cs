using CASolution.Application.services.WeatherForecast;
using ErrorOr;

namespace CASolution.Application.Interfaces.WeatherForecast;

public interface IWeatherForecastSerivce
{
    Task<ErrorOr<IEnumerable<WeatherForecastResult>>> GetWeatherForecast();
}