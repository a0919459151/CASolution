using ErrorOr;

namespace CASolution.Domain.Errors;

public static class Errors
{
    public static class WeatherForecast
    {
        public static Error NotFound => Error.NotFound(
            code: "WeatherForecast.NotFound",
            description: "Weather forecast not found.");
    }
}
