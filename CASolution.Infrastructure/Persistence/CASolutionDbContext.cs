using CASolution.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CASolution.Infrastructure.Persistence;

public class CASolutionDbContext : DbContext
{
    public DbSet<WeatherForecast> WeatherForecasts { get; set; }

    public CASolutionDbContext(DbContextOptions<CASolutionDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CASolutionDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
