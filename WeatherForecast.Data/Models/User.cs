using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Data.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
        public int RoleId { get; set; }
        public string LoggingErrorMessage { get; set; }
    }
}
