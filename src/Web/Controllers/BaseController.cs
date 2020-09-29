using Locadora.Domain;
using Simple.Validation;
using System.Globalization;
using System.Runtime.Serialization;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Locadora.Web.Areas.Controllers
{
    public partial class BaseController : Controller
    {
        protected override void OnException(ExceptionContext filterContext)
        {
            //if (filterContext.HttpContext.IsCustomErrorEnabled && !(filterContext.Exception is AuthorizationException))
            //{
            //    filterContext.ExceptionHandled = true;
            //    var code = filterContext.Exception.GetType().Name;
            //    var message = filterContext.Exception.Message;
            //    var stackTrace = "";
            //    while (filterContext.Exception != null)
            //    {
            //        stackTrace += filterContext.Exception.GetType().Name + "\n" + filterContext.Exception.StackTrace + "\n\n";
            //        filterContext.Exception = filterContext.Exception.InnerException;
            //    }
            //    ViewBag.Code = code;
            //    ViewBag.Message = message;
            //    ViewBag.StackTrace = stackTrace;
            //    this.View("erro").ExecuteResult(this.ControllerContext);
            //}
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ViewBag.Alerta = TempData["Alerta"];
        }

        protected ActionResult HandleViewException<T>(T model, SimpleValidationException ex)
        {
            ModelState.Clear();
            foreach (var item in ex.Errors)
                ModelState.AddModelError(item.PropertyName, item.Message);
            return View(model);
        }

        //protected void ConfigurarLinguagem(TClient client)
        //{
        //    if (client != null && !string.IsNullOrEmpty(client.Language))
        //    {
        //        if (client.Language == "pt")
        //            client.Language = "pt-br";
        //        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(client.Language);
        //        Thread.CurrentThread.CurrentUICulture = new CultureInfo(client.Language);
        //        var cookie = Request.Cookies["linguagem"];
        //        if (cookie == null)
        //            cookie = new HttpCookie("linguagem") { Value = client.Language };
        //        if (cookie.Value != client.Language)
        //            cookie.Value = client.Language;
        //        Response.Cookies.Add(cookie);
        //    }
        //}
    }
}