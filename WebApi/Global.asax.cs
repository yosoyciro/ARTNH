using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using NHibernate;

namespace WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        public static ISessionFactory SessionFactory
        {
            get;
            private set;
        }
        //GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        //GlobalConfiguration.Configuration.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);
        protected void Application_Start()
        {
            //{
            //    if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
            //    {
            //        //These headers are handling the "pre-flight" OPTIONS call sent by the browser
            //        HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE");
            //        HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Accept");
            //        HttpContext.Current.Response.AddHeader("Access-Control-Allow‌​-Credentials", "true");
            //        HttpContext.Current.Response.AddHeader("Access-Control-Max-Age", "1728000");
            //        HttpContext.Current.Response.End();
            //    }
            //}
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Inicio la sesion por unica vez
            SessionFactory = SL.GenerarSesion.Instance.SessionFactory();
        }
    }
}
