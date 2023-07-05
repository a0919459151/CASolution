namespace CASolution.Api.Contracts;

public class CreateWeatherForecastRequest
{
    public DateOnly Date { get; set; }

    public int TemperatureC { get; set; }
}
