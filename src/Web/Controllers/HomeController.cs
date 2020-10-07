using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Simple.Web.Mvc;
using System.CodeDom.Compiler;
using Locadora.Web.Areas.Controllers;
using Locadora.Web.Helpers;
using Locadora.Domain;
using System.Web.Security;
using System.Security.Principal;
using System.Threading;
using System.Globalization;

namespace Locadora.Web.Controllers
{
    public partial class HomeController : BaseController
    {
        [RequiresAuthorization]
        public virtual ActionResult Index()
        {
            return View();
        }

        public virtual ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public virtual ActionResult Login(Login model)
        {
            model.SudDomain = Subdomain.Painel;
            var usuario = TClient.Authenticate(model);
            if (usuario != null)
            {
                FormsAuthentication.SetAuthCookie(model.Username, model.Remember);
                HttpContext.User = new GenericPrincipal(new GenericIdentity(model.Username), new string[] { });

                var idioma = "pt-br";
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(idioma);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(idioma);
                var cookie = Request.Cookies["linguagem"];
                if (cookie == null)
                    cookie = new HttpCookie("linguagem") { Value = idioma };
                if (cookie.Value != idioma)
                    cookie.Value = idioma;
                Response.Cookies.Add(cookie);

                if (!string.IsNullOrWhiteSpace(model.ReturnUrl))
                    return Redirect(model.ReturnUrl);
                return RedirectToAction(MVC.Home.Index());
            }
            else
            {
                ViewBag.Alerta = new Alert("error", TClient.GetErrorLogin(model));
                return View(model);
            }
        }

        public virtual ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction(MVC.Home.Index());
        }

        [ActionName("erro-404")]
        public virtual ActionResult Erro404()
        {
            return View((TUser)ViewBag.Usuario);
        }

        [ActionName("acesso-negado")]
        public virtual ActionResult AcessoNegado()
        {
            return View();
        }

        [ActionName("teste-linguagem")]
        public virtual ActionResult TesteLinguagem(string Linguagem)
        {
            ViewBag.Linguagem = CultureInfo.GetCultures(CultureTypes.InstalledWin32Cultures).OrderBy(x => x.Name).ToSelectList(x => x.Name, x => x.Name + " - " + x.EnglishName);
            if (!string.IsNullOrWhiteSpace(Linguagem))
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Linguagem);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Linguagem);
            }
            var cookie = new HttpCookie("linguagem");
            cookie.Value = Linguagem;
            Response.Cookies.Add(cookie);

            return View();
        }

        [RequiresAuthorization, ActionName("importar-arquivo")]
        public virtual ActionResult ImportarArquivo()
        {
            /*var clientes = TClient.List(x => x.EnumPersonType == PersonType.PJ && !x.IsCanceled);
            foreach (var item in clientes)
            {
                var socios = item.Partners;
                var titular = socios.First();
                item.Name = titular.Name;
                item.EnumPersonType = PersonType.PF;
                item.PersonDocument = titular.PersonDocument.RemoveSpecialCaracteres();
                if (titular.BirthDate.HasValue)
                    item.BirthDate = titular.BirthDate.Value;
                item.StateRegistration = null;
                item.Update();
                titular.Delete();
            }*/
            return View();
        }
    }
}
