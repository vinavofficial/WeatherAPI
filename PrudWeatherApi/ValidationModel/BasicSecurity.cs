using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrudWeatherApi.ValidationModel
{
    public class BasicSecurity
    {
        //Basic authentication
        public static bool Validateuser(string username, string password)
        {
            return (username == "Prudential" && password == "App$123");
        }     
    }
}
