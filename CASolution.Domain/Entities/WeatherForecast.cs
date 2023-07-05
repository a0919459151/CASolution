namespace CASolution.Domain.Entities;

public class WeatherForecast
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public Guid Id { get; set; }

    public DateOnly Date { get; set; }

    public int TemperatureC { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public string Summary => TemperatureC switch
    {
        < -10 => Summaries[0],
        < 0 => Summaries[1],
        < 10 => Summaries[2],
        < 20 => Summaries[3],
        < 30 => Summaries[4],
        < 40 => Summaries[5],
        < 50 => Summaries[6],
        < 60 => Summaries[7],
        < 70 => Summaries[8],
        >= 70 => Summaries[9]
    };
}
