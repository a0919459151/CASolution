using CASolution.Application.Interfaces.WeatherForecast;
using CASolution.Domain.Errors;
using CASolution.Infrastructure.Persistence;
using ErrorOr;

namespace CASolution.Application.services.WeatherForecast;

public class WeatherForecastSerivce : IWeatherForecastSerivce
{
    private readonly IWeatherRepository _weatherRepository;

    public WeatherForecastSerivce(IWeatherRepository weatherRepository)
    {
        _weatherRepository = weatherRepository;
    }

    public async Task<ErrorOr<IEnumerable<WeatherForecastResult>>> GetWeatherForecast()
    {
        var weathers = await _weatherRepository.GetWeatherForecastAsync();

        if (!weathers.Any())
        {
            return Errors.WeatherForcast.NotFound;
        }

        var results = weathers.Select(w => new WeatherForecastResult
        {
            Date = w.Date,
            TemperatureC = w.TemperatureC,
        });

        return ErrorOrFactory.From(results);
    }
}
