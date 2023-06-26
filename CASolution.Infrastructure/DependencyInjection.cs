using CASolution.Application.Interfaces.Persistence;
using CASolution.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace CASolution.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IWeatherRepository, WeatherRepository>();
        return services;
    }
}