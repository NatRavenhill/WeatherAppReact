using System.Text.Json.Serialization;

namespace WeatherAppReact.Models
{
    /// <summary>
    /// A location from the API
    /// </summary>
    public class Location
    {
        /// <summary>
        /// Title
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        /// Wherr On Earth Id
        /// </summary>
        [JsonPropertyName("woeid")]
        public int WhereOnEarthId { get; set; }

    }
}
