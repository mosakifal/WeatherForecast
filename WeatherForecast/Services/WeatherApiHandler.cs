using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using WeatherForecast.Models;

namespace WeatherForecast.Services
{
    public class WeatherApiHandler : IWeatherApiHandler
    {
        public string ApiEndpoint
        {
            get
            {
                return ConfigurationManager.AppSettings["apiEndpoint"];
            }
        }

        public IEnumerable<Weather> GetWeather()
        {
            var client = new HttpClient();

            var results = new List<Weather>();

            var response = client.GetAsync(ApiEndpoint).Result;

            if (response.IsSuccessStatusCode)
            {
                string responseString = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<dynamic>(responseString);
                foreach (var item in data.consolidated_weather)
                {
                    results.Add(new Weather
                    {
                        State = item.weather_state_name,
                        Date = item.applicable_date,
                        Image = item.weather_state_abbr + ".png"
                    });
                }
                if (results.Any())
                {
                    results.RemoveAt(0);
                }
                return results;
            }

            return null;
        }
    }
}