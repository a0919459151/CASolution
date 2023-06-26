using CASolution.Application.Interfaces.Persistence;
using CASolution.Domain.Errors;
using ErrorOr;

namespace CASolution.Application.services.WeatherForecast;

public class WeatherForecastService : IWeatherForecastService
{
    private readonly IWeatherRepository _weatherRepository;

    public WeatherForecastService(IWeatherRepository weatherRepository)
    {
        _weatherRepository = weatherRepository;
    }

    public async Task<ErrorOr<IEnumerable<WeatherForecastResult>>> GetWeatherForecast()
    {
        var weathers = await _weatherRepository.GetWeatherForecastAsync();

        if (!weathers.Any())
        {
            return Errors.WeatherForecast.NotFound;
        }

        var results = weathers.Select(w => new WeatherForecastResult
        {
            Date = w.Date,
            TemperatureC = w.TemperatureC,
        });

        return ErrorOrFactory.From(results);
    }
}
