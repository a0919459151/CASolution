namespace CASolution.Api.Contracts;

public class GetWeatherForecastResponse
{
    public DateOnly Date { get; set; }

    public int TemperatureC { get; set; }

    public int TemperatureF { get; set; }

    public string Summary { get; set; } = null!;
}
