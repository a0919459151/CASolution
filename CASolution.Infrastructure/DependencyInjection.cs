using CASolution.Application.Interfaces.Persistence;
using CASolution.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CASolution.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CASolutionDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("CASolutionConnectionString"));
        });
        services.AddScoped<IWeatherRepository, WeatherForecastRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }
}
