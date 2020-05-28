using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Models;

namespace WeatherForecast.Services
{
    public interface IWeatherApiHandler
    {
        IEnumerable<Weather> GetWeather();
    }
}
