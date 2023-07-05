namespace CASolution.Api.Contracts;

public class UpdateWeatherForecastRequest
{
    public DateOnly Date { get; set; }

    public int TemperatureC { get; set; }
}
