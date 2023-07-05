using ErrorOr;

namespace CASolution.Domain.Errors;

public static class Errors
{
    public static class WeatherForecast
    {
        public static Error NotFound => Error.NotFound(
            code: "WeatherForecast.NotFound",
            description: "Weather forecast not found.");

        public static Error Conflict => Error.Conflict(
            code: "WeatherForecast.Conflict",
            description: "Weather forecast already exist.");
    }
}
