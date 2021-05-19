using System.Text.Json.Serialization;

namespace WeatherAppReact.Models
{
    /// <summary>
    /// Response from the API for a given location
    /// </summary>
    public class WeatherResponse
    {
        /// <summary>
        /// A consolidated list of forecasts
        /// </summary>
        [JsonPropertyName("consolidated_weather")]
        public Forecast[] ConsolidatedWeather { get; set; }
    }
}
