using CASolution.Application.Interfaces.Persistence;
using CASolution.Domain.Errors;
using ErrorOr;
using WeatherForecastEntity = CASolution.Domain.Entities.WeatherForecast;
using Mapster;

namespace CASolution.Application.services.WeatherForecast;

public class WeatherForecastService : IWeatherForecastService
{
    private readonly IWeatherRepository _weatherRepository;

    private readonly IUnitOfWork _unitOfWork;

    public WeatherForecastService(IWeatherRepository weatherRepository, IUnitOfWork unitOfWork)
    {
        _weatherRepository = weatherRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<IEnumerable<WeatherForecastResult>>> GetWeatherForecast()
    {
        var weathers = await _weatherRepository.GetWeatherForecast();

        if (!weathers.Any())
        {
            return Errors.WeatherForecast.NotFound;
        }

        var results = weathers.Select(w => w.Adapt<WeatherForecastResult>());

        return ErrorOrFactory.From(results);
    }

    public async Task<ErrorOr<WeatherForecastResult>> CreateWeatherForecast(WeatherForecastEntity request)
    {
        var isExistWeatherForecast = _weatherRepository.IsExistWeatherForecastByDate(request.Date);
        if (isExistWeatherForecast)
            return Errors.WeatherForecast.Conflict;

        _weatherRepository.CreateWeatherForecast(request);

        await _unitOfWork.SaveChangesAsync();

        var res = request.Adapt<WeatherForecastResult>();
        return ErrorOrFactory.From(res);
    }

    public async Task<ErrorOr<WeatherForecastResult>> UpdateWeatherForecast(WeatherForecastEntity request)
    {
        var weatherForecast = await _weatherRepository.GetWeatherForecastByDate(request.Date);
        if (weatherForecast is null)
            return Errors.WeatherForecast.NotFound;

        weatherForecast.Date = request.Date;
        weatherForecast.TemperatureC = request.TemperatureC;

        await _unitOfWork.SaveChangesAsync();

        return ErrorOrFactory.From(request.Adapt<WeatherForecastResult>());
    }
}
