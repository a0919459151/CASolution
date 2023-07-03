using CASolution.Application.Interfaces.Persistence;
using CASolution.Domain.Errors;
using ErrorOr;
using WeatherForecastEntity = CASolution.Domain.Entities.WeatherForecast;

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
        var weathers = await _weatherRepository.GetWeatherForecast();

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

    public async Task<ErrorOr<WeatherForecastResult>> UpsertWeatherForecast(WeatherForecastEntity request)
    {
        var weatherForecast = await _weatherRepository.GetWeatherForecastByDate(request.Date);

        var result = weatherForecast is null
            ? await _weatherRepository.CreateWeatherForecast(request)
            : await _weatherRepository.UpdateWeatherForecast(request);

        return new WeatherForecastResult
        {
            Date = result.Date,
            TemperatureC = result.TemperatureC
        };
    }
}
