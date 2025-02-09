using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Simple.Patterns;
using Simple;
using Locadora.Services;
using System.Reflection;
using Locadora.Web.Helpers;
using Simple.Web.Mvc;
using System.IO;
using System.Security.Permissions;
using System.Security.Principal;
using System.Security.AccessControl;

namespace Locadora.Web.Controllers
{
    public partial class SystemController : Controller
    {
        public SystemController()
        {
            TempDataProvider = new NullTempDataProvider();
        }
        public virtual ActionResult Index()
        {
            var runner = new TaskRunner();

            runner.RunChained("Can access business server", "Success",
                x => Simply.Do.Resolve<ISystemService>().Check());

            return View(runner.Results);
        }
        public virtual ActionResult Error(Exception exception)
        {
            ViewData["code"] = exception.GetType().Name;
            ViewData["message"] = exception.Message;

            ViewData["stacktrace"] = "";
            while (exception != null)
            {
                ViewData["stacktrace"] += exception.GetType().Name + "\n" + exception.StackTrace + "\n\n";
                exception = exception.InnerException;
            }
            Response.StatusCode = 500;
            return View();
        }

    }
}
