using ErrorOr;

namespace CASolution.Domain.Errors;

public static class Errors
{
    public static class WeatherForcast
    {
        public static Error NotFound => Error.NotFound(
            code: "WeatherForcast.NotFound",
            description: "Weather forcast not found.");
    }
}
