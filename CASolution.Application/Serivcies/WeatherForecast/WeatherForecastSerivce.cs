using CASolution.Application.Interfaces.WeatherForecast;
using CASolution.Infrastructure.Persistence;

namespace CASolution.Application.Serivcies.WeatherForecast;

public class WeatherForecastSerivce : IWeatherForecastSerivce
{
    private readonly IWeatherRepository _weatherRepository;

    public WeatherForecastSerivce(IWeatherRepository weatherRepository)
    {
        _weatherRepository = weatherRepository;
    }

    public async Task<IEnumerable<WeatherForecastResult>> GetWeatherForecast()
    {
        var weathers = await _weatherRepository.GetWeatherForecastAsync();

        return weathers.Select(x => new WeatherForecastResult
        {
            Date = x.Date,
            TemperatureC = x.TemperatureC,
        });
    }
}
