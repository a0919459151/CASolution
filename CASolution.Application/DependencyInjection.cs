using CASolution.Application.services.WeatherForecast;
using Microsoft.Extensions.DependencyInjection;

namespace CASolution.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IWeatherForecastService, WeatherForecastService>();
        return services;
    }
}