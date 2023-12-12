using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebApiCliente
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Trace.WriteLine("La aplicación ha iniciado correctamente.");
        }

        protected void Application_Error()
        {
            var ex = Server.GetLastError();
            Trace.TraceError($"Excepción: {ex.Message}");
        }

        protected void Application_End()
        {
            Trace.WriteLine("La aplicación ha finalizado correctamente.");
        }

    }
}
