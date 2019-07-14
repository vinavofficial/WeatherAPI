using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrudWeatherApi.Controllers;
using System.Net.Http;
using System.Web.Http;
using System.Net;
using PrudWeatherApi.AuthenticationFilters;
using System.Collections.Generic;

namespace Weather.Test
{
    [TestClass]
    public class WeatherTest
    {
        [TestMethod]
        public void GetCityWiseWeatherData_Test()
        {

            var controller = new WeatherController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            List<string> citylist = new List<string> { "Mumbai", "New york", "Delhi", "London", "Moscow" };
            var response = controller.GetCityWiseWeatherData(citylist);

            Assert.IsTrue(response.IsSuccessStatusCode);
        }
    }
}
