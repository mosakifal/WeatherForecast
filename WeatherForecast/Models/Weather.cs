using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherForecast.Models
{
    public class Weather
    {
        public string State { get; set; }
        public DateTime Date { get; set; }
        public string Image { get; set; }
    }
}