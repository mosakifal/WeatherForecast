using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Data.Models;

namespace WeatherForecast.Data.Services
{
    public interface IUserData
    {
        IEnumerable<User> GetAll();
        UserRole GetUserRoleByUserId(int userId);
    }
}
