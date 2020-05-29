using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeatherForecast.Services;

namespace WeatherForecast.Controllers
{
    public class ForecastController : Controller
    {
        private readonly IWeatherApiHandler _apiHandler;

        public ForecastController(IWeatherApiHandler apiHandler)
        {
            _apiHandler = apiHandler;
        }

        [CustomAuthorize("Admin")]
        public ActionResult Index()
        {
           if (Session["UserId"] == null)
           {
               Response.Redirect("~/Account/Index");
           }
           var model = _apiHandler.GetWeather();

           if(model == null)
           {
                return View("NotFound");
           }

           return View(model);
        }
    }
}