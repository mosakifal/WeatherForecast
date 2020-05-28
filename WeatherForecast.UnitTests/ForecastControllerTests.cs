using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WeatherForecast.Controllers;
using WeatherForecast.Models;
using WeatherForecast.Services;

namespace WeatherForecast.UnitTests
{
    [TestClass]
    public class ForecastControllerTests
    {
        Mock<IWeatherApiHandler> _mockWeatherApiHandler;
        ForecastController _controller;
        List<Weather> _model;

        [TestInitialize]
        public void Setup()
        {
            _mockWeatherApiHandler = new Mock<IWeatherApiHandler>();
            _controller = new ForecastController(_mockWeatherApiHandler.Object);
            SetTestData();
        }

        private void SetTestData()
        {
            _model = new List<Weather>
            {
                new Weather
                {
                    Date = DateTime.Now.AddDays(1),
                    State = "Heavy Cloud",
                    Image = "hc.png"
                },
                new Weather
                {
                    Date = DateTime.Now.AddDays(2),
                    State = "Light Cloud",
                    Image = "lc.png"
                },
                new Weather
                {
                    Date = DateTime.Now.AddDays(3),
                    State = "Showers",
                    Image = "s.png"
                },
                new Weather
                {
                    Date = DateTime.Now.AddDays(4),
                    State = "Light Cloud",
                    Image = "lc.png"
                },
                new Weather
                {
                    Date = DateTime.Now.AddDays(5),
                    State = "Light Cloud",
                    Image = "lc.png"
                },
            };
        }

        [TestMethod]
        public void ForecastController_ModelState_IsValid()
        {
            //Arrange
            _mockWeatherApiHandler.Setup(x => x.GetWeather()).Returns(_model);

            //Act
            var result = _controller.ModelState.IsValid;

            //Assert
            Assert.IsTrue(result);
            Assert.AreEqual(_model.Count, 5);
        }

    }
}
