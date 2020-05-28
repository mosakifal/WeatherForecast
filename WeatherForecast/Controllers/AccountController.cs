using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeatherForecast.Data.Models;
using WeatherForecast.Data.Services;

namespace WeatherForecast.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserData _dbUser;

        public AccountController(IUserData dbUser)
        {
            _dbUser = dbUser;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            var usr = _dbUser.GetAll().Where(x => x.Username == user.Username && x.Password == user.Password).FirstOrDefault();
            if(usr!= null)
            {
                Session["UserId"] = usr.UserId;
                Session["Username"] = usr.Username;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Invalid Username or Password");
            }
            return View("Index", user);
        }

        public ActionResult LogOut()
        {
            int userId = (int) Session["UserId"];
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}