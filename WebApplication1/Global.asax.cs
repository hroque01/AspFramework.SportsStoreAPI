using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace WebApplication1
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            GlobalConfiguration.Configure(WebApiConfig.Register);

        }
        protected void Session_Start(object sender, EventArgs e) {
        }
        protected void Application_BeginRequest()
        {
            // Questo metodo viene invocato all'inizio di ogni richiesta HTTP

            if (Request.HttpMethod == "OPTIONS")
            {
                // Se il metodo della richiesta HTTP è OPTIONS, 
                // risponde immediatamente con lo stato OK (200)
                // Questo è un comportamento comune nelle API REST per gestire le richieste di pre-volo CORS

                Response.StatusCode = (int)HttpStatusCode.OK;
                Response.End();
            }
        }
        protected void Application_AuthenticateRequest(object sender, EventArgs e) { 
        }
        protected void Application_Error(object sender, EventArgs e) { 
        }
        protected void Session_End(object sender, EventArgs e) {
        }
        protected void Application_End(object sender, EventArgs e) { 
        }

    }
}