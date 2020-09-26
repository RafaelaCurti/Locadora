using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Simple;
using Locadora.Web.Controllers;
using Locadora.Web.Helpers;
using Simple.Entities;
using Simple.Reflection;
using Simple.Web.Mvc;
using Simple.Threading;
using System.Globalization;
using System.Threading;

namespace Locadora.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("elmah.axd");
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapLowercaseRoute("Default", // Route name 
                "{controller}/{action}/{id}", // URL with parameters 
                new { controller = "Home", action = "Index", id = "" }, // Parameter defaults 
                new string[] { "Locadora.Web.Controllers" });
        }

        protected static void MapDefault(RouteCollection routes, string name, params string[] patterns)
        {
            for (int i = 0; i < patterns.Length; i++)
            {
                routes.MapRoute(name + i, patterns[i],
                    new { controller = "Home", action = "Index", id = 0, format = "html" },
                    new { controller = "[^\\.]*", action = "[^\\.]*", id = "[^\\.]*", format = "[^\\.]*" }
                );
            }
        }

        protected void Application_Start()
        {
            CultureInfo ci = new CultureInfo("pt-BR");
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;

            AreaRegistration.RegisterAllAreas();
            RegisterRoutes(RouteTable.Routes);

            DefaultModelBinder.ResourceClassKey = typeof(ValidationMessages).Name;
            ModelBinders.Binders.DefaultBinder = new EntityModelBinder();

            ModelValidatorProviders.Providers.Clear();

            SimpleContext.SwitchProvider(new HttpContextProvider());
            new Configurator().StartServer<ServerStarter>();
        }

        protected void Application_BeginRequest()
        {
            Simply.Do.EnterContext();
        }

        protected void Application_EndRequest()
        {
            var ctx = Simply.Do.GetContext(false);
            if (ctx != null) ctx.Dispose();
        }
    }
}