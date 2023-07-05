using CASolution.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CASolution.Infrastructure.Persistence.config;

public class WeatherForecastConfigs : IEntityTypeConfiguration<WeatherForecast>
{
    public void Configure(EntityTypeBuilder<WeatherForecast> builder)
    {
        // convert DateOnly to DateTime
        builder.Property(w => w.Date).HasConversion(
            v => v.ToDateTime(TimeOnly.MinValue),
            v => DateOnly.FromDateTime(v)
        );

        // ignore TemperatureF, Summary
        builder.Ignore(w => w.TemperatureF);
        builder.Ignore(w => w.Summary);
    }
}
