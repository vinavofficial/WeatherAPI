using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PrudWeatherApi.AuthenticationFilters;
using System.Threading;
namespace PrudWeatherApi.Controllers
{

    public class WeatherController : ApiController
    {
        // GET api/<controller>
        //Pass the city list by comma separated values
        [BasicAuthenticationFilter]
        [HttpGet]
        public HttpResponseMessage GetCityWiseWeatherData(List<string> cityList)
        {
            if (cityList !=null)
            {
                try
                {
                    string folderName = @"C:\WeatherService\";
                    foreach (var cityname in cityList)
                    {
                        string url = string.Format("https://api.openweathermap.org/data/2.5/weather?q={0}&appid=aa69195559bd4f88d79f9aadeb77a8f6", cityname);
                        using (WebClient client = new WebClient())
                        {
                            string Weatherinfo = client.DownloadString(url);
                            string pathString = Path.Combine(folderName + cityname + "  " + DateTime.Now.Year.ToString());
                            Directory.CreateDirectory(pathString);
                            string fileName = DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Year.ToString();
                            pathString = Path.Combine(pathString, fileName);
                            File.WriteAllText(pathString + " .json", Weatherinfo);
                        }
                    }
                }
                catch (FileNotFoundException ex)
                {
                    throw new FileNotFoundException(ex.Message);
                }
                catch (DirectoryNotFoundException ex)
                {
                    throw new DirectoryNotFoundException(ex.Message);
                }
                catch (UriFormatException ex)
                {
                    throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message));
                }
                return Request.CreateResponse(HttpStatusCode.OK, "Weather files are created succesfully for " + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Year.ToString() + "day ");
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "City list cannot be empty");
        }
    }
}