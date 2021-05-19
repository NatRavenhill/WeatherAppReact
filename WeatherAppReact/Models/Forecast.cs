using System;
using System.Text.Json.Serialization;

namespace WeatherAppReact.Models
{
    /// <summary>
    /// Represents an individual forecast
    /// </summary>
    public class Forecast
    {
        /// <summary>
        /// Forecast ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Date of forecast
        /// </summary>
        [JsonPropertyName("applicable_date")]
        public DateTime Date { get; set; }

        /// <summary>
        /// Weather state
        /// </summary>
        [JsonPropertyName("weather_state_name")]
        public string StateName { get; set; }

        /// <summary>
        /// Abbreviated state
        /// </summary>
        [JsonPropertyName("weather_state_abbr")]
        public string AbbreviatedState { get; set; }

        /// <summary>
        /// Location of weather state image
        /// </summary>
        public string ImageLocation => $"https://www.metaweather.com/static/img/weather/png/{ AbbreviatedState }.png";
    }
}
