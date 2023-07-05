namespace CASolution.Api.Contracts;

public class CreateWeatherForecastResponse
{
    public DateOnly Date { get; set; }

    public int TemperatureC { get; set; }

    public int TemperatureF { get; set; }

    public string Summary { get; set; } = null!;
}
