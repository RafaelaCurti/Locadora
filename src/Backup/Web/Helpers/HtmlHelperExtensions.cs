using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Simple;
using Simple.Web.Mvc;
using MvcContrib.FluentHtml.Elements;
using System.Collections;
using MvcContrib.FluentHtml;
using MvcContrib.FluentHtml.Expressions;
using System.Linq.Expressions;
using Simple.Common;
using Simple.Entities;
using Simple.Validation;
namespace Locadora.Web.Helpers
{
    public static class HtmlHelperExtensions
    {
        public static ViewResult DeleteView(this Controller controller, object itemName, params object[] objs)
        {
            return ConfirmView(controller, "Tem certeza que desejal apagar '{0}'?", (itemName ?? "").ToString().AsFormatFor(objs));
        }

        public static ViewResult ConfirmView(this Controller controller, object text, params object[] objs)
        {
            var view = new ViewResult() { ViewName = "_Confirm", ViewData = controller.ViewData, TempData = controller.TempData };
            view.ViewBag.ConfirmMessage = (text ?? "").ToString().AsFormatFor(objs);
            return view;
        }

        public static string ActionAbsolute(this UrlHelper url, string action)
        {
            Uri requestUrl = url.RequestContext.HttpContext.Request.Url;
            string absoluteAction = string.Format("{0}://{1}{2}", requestUrl.Scheme, requestUrl.Authority, action);
            return absoluteAction;
        }
    }
}
