using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Data.Models;

namespace WeatherForecast.Data.Services
{
    /// <summary>
    /// In a real application this will be replaced by a database context
    /// </summary>
    public class InMemoryUserData : IUserData
    {
        List<User> _users;
        List<UserRole> _userRoles;

        public InMemoryUserData()
        {
            _userRoles = new List<UserRole>
            {
                new UserRole {Id = 1, Name = "Admin"},
                new UserRole {Id = 2, Name = "Sales"},
                new UserRole {Id = 3, Name = "HR"}
            };
            _users = new List<User>
            {
                new User {UserId = 1, Username = "mohamed", Password = "mohamed123", RoleId = 1 },
                new User {UserId = 2, Username = "james", Password = "james123", RoleId = 2 },
                new User {UserId = 2, Username = "katy", Password = "katy123", RoleId = 3 }
            };
        }

        public IEnumerable<User> GetAll()
        {
            return _users;
        }

        public UserRole GetUserRoleByUserId(int userId)
        {
            return _userRoles.Where(x => x.Id == userId).FirstOrDefault();
        }
    }
}
