using CASolution.Application.Interfaces.Persistence;
using CASolution.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CASolution.Infrastructure.Persistence;

public class WeatherForecastRepository : IWeatherRepository
{
    private readonly CASolutionDbContext _dbContext;

    public WeatherForecastRepository(CASolutionDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public bool IsExistWeatherForecastByDate(DateOnly date)
    {
        return _dbContext.WeatherForecasts.AsNoTracking().Any(w => w.Date == date);
    }

    public async Task<IEnumerable<WeatherForecast>> GetWeatherForecast()
    {
        return await _dbContext.WeatherForecasts.ToListAsync();
    }

    public async Task<WeatherForecast?> GetWeatherForecastByDate(DateOnly date)
    {
        var weatherForecast = await _dbContext.WeatherForecasts.FirstOrDefaultAsync(w => w.Date == date);
        if (weatherForecast is null)
        {
            return null;
        }
        return weatherForecast;
    }

    public void CreateWeatherForecast(WeatherForecast weatherForecast)
    {
        _dbContext.WeatherForecasts.Add(weatherForecast);
    }

    public void UpdateWeatherForecast(WeatherForecast weatherForecast)
    {
        _dbContext.WeatherForecasts.Update(weatherForecast);
    }
}
