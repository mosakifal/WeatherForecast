using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeatherForecast.Data.Services;
using WeatherForecast.Services;

namespace WeatherForecast.App_Start
{
    public class ContainerConfig
    {
        internal static void RegisterContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<InMemoryUserData>()
                   .As<IUserData>()
                   .SingleInstance();
            builder.RegisterType<WeatherApiHandler>()
                   .As<IWeatherApiHandler>()
                   .SingleInstance();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}