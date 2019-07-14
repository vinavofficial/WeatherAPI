using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using System.Web.Http.Controllers;
using System.Net.Http;
using System.Net;
using System.Threading;
using PrudWeatherApi.ValidationModel;
using System.Security.Principal;

namespace PrudWeatherApi.AuthenticationFilters
{
    public class BasicAuthenticationFilter:AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null) 
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, "Please enter username & password");
            }
            else
            {
                string authenticationToken = actionContext.Request.Headers.Authorization.Parameter;
                string decodeAuthenticationToken= Encoding.UTF8.GetString(Convert.FromBase64String(authenticationToken));
                string[] usernamepasswordarray = decodeAuthenticationToken.Split(':');
                string username = usernamepasswordarray[0];
                string password = usernamepasswordarray[1];

                if (!BasicSecurity.Validateuser(username, password))
                {
                    //Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(username), null);
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, "You are not authorized to use this services.");
                }
            }
        }
    }
}
