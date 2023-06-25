using CASolution.Application.Interfaces.WeatherForecast;
using CASolution.Application.Serivcies.WeatherForecast;
using Microsoft.Extensions.DependencyInjection;

namespace CASolution.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IWeatherForecastSerivce, WeatherForecastSerivce>();
        return services;
    }
}