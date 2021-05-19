using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WeatherAppReact.Models;

namespace WeatherAppReact.Controllers
{
    /// <summary>
    /// Controller for the weather forecasts page
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private HttpClient client;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        private async Task<string?> QueryAPI(string query)
        {
            HttpResponseMessage response = await client.GetAsync(query);
            HttpStatusCode statusCode = response.StatusCode;

            if (statusCode == HttpStatusCode.OK)
            {
                string asString = await response.Content.ReadAsStringAsync();
                return asString;
            }


            return null;

        }

        /// <summary>
        /// Get the weather forecasts from the MetaWeatherAPI
        /// </summary>
        /// <returns>A list of weather forecasts</returns>
        [HttpGet]
        public async Task<IEnumerable<Forecast>> GetAsync()
        {
            client = new HttpClient
            {
                BaseAddress = new Uri("https://www.metaweather.com/api/")
            };

            string response = await QueryAPI("location/search/?query=belfast");
            Location[] foundLocation = JsonSerializer.Deserialize<Location[]>(response);
            if (response == null)
                return new List<Forecast>();

            response = await QueryAPI($"location/{foundLocation[0].WhereOnEarthId}/");
            if (response == null)
                return new List<Forecast>();

            WeatherResponse weatherResponse = JsonSerializer.Deserialize<WeatherResponse>(response);

            return weatherResponse.ConsolidatedWeather.ToList();
        }
    }
}
