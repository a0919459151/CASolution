namespace CASolution.Api.Contracts;

public class UpsertWeatherForecastRequest
{
    public DateOnly Date { get; set; }

    public int TemperatureC { get; set; }
}
