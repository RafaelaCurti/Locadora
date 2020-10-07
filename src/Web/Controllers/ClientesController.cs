using Locadora.Domain;
using Locadora.Helpers;
using Locadora.Web.Areas.Controllers;
using Locadora.Web.Helpers;
using NHibernate.SqlCommand;
using Simple.Validation;
using Simple.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Locadora.Web.Controllers
{
    public partial class ClientesController : BaseController
    {
        public object Recaptcha { get; private set; }

        [RequiresAuthorization]
        public virtual ActionResult Index()
        {
            var clientes = TClient.ListAll().ToList();
            return View(clientes);
        }

        [RequiresAuthorization]
        public virtual ActionResult Cadastrar()
        {
            var cliente = new TClient();
            ViewBag.MostraSenha = true;
            ViewBag.EnumProfileClient = EnumHelper.ListAll<ProfileClient>().ToSelectList(x => x, x => x.Description());
            ViewBag.Genero = TMovieCategory.ListAll().ToSelectList(x => x.Category.Id, x => x.Category.Name);
            return View(cliente);
        }

        [HttpPost, ValidateInput(false), RequiresAuthorization]
        public virtual ActionResult Cadastrar(TClient model)
        {
            try
            {
                model.Password = TClient.HashPassword(model.PasswordString);
                TempData["Alert"] = new Alert("success", "Seu cliente foi cadastrado com sucesso");
                model.Save();
                TPreference.SavePreferences(model);
                return RedirectToAction("Index");
            }
            catch (SimpleValidationException ex)
            {
                ViewBag.MostraSenha = true;
                ViewBag.EnumProfileClient = EnumHelper.ListAll<ProfileClient>().ToSelectList(x => x, x => x.Description());
                return HandleViewException(model, ex);
            }
        }

        [RequiresAuthorization]
        public virtual ActionResult Editar(int id)
        {
            var cliente = TClient.Load(id);
            ViewBag.MostraSenha = false;
            ViewBag.EnumProfileClient = EnumHelper.ListAll<ProfileClient>().ToSelectList(x => x, x => x.Description());
            ViewBag.Genero = TMovieCategory.ListAll().ToSelectList(x => x.Category.Id, x => x.Category.Name);
            return View(cliente);
        }

        [HttpPost, ValidateInput(false), RequiresAuthorization]
        public virtual ActionResult Editar(TClient model)
        {
            try
            {
                model.Edit();
                TPreference.SavePreferences(model);
                TempData["Alerta"] = new Alert("success", "Seu cliente foi ceditado com sucesso");
                return RedirectToAction("Index");
            }
            catch (SimpleValidationException ex)
            {
                ViewBag.MostraSenha = false;
                ViewBag.EnumProfileClient = EnumHelper.ListAll<ProfileClient>().ToSelectList(x => x, x => x.Description());
                return HandleViewException(model, ex);
            }
        }
        public virtual ActionResult ListarPreferencia(int id)
        {
            var preference = TCategory.Load(id);
            return PartialView("_listar-preferencias", preference);
        }
        public virtual ActionResult Excluir(int id)
        {
            var cliente = TClient.Load(id);
            return PartialView("_excluir", cliente);
        }

        [HttpPost]
        public virtual ActionResult Excluir(int id, object diff)
        {
            TPreference.Delete(x => x.Client.Id == id);
            TClient.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public virtual ActionResult Login(Login model)
        {
            model.SudDomain = Subdomain.Backoffice;
            model.NeedsToBeActive = false;
            model.NeedsToBeConfirmed = false;
            //model.RequiresCaptcha = TParameter.FindByEnum(Parameter.LoginWithCaptcha) != null
            //Colocar no ClientServer

            //aqui
            var membro = TClient.Authenticate(model);

            FormsAuthentication.SetAuthCookie(membro.Login, true);
            if (membro != null)
            {
                FormsAuthentication.SetAuthCookie(membro.Login, model.Remember);
                HttpContext.User = new GenericPrincipal(new GenericIdentity(membro.Login), new string[] { });

                if (!string.IsNullOrWhiteSpace(model.ReturnUrl))
                    return Redirect(model.ReturnUrl);
                return RedirectToAction(MVC.Clientes.Index());
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
            if (HttpContext.Session != null)
            {
                HttpContext.Session["ReadOnly"] = null;
                HttpContext.Session["AdminAccess"] = null;
                HttpContext.Session["Layout"] = null;
            }
            return RedirectToAction(MVC.Home.Index());
        }

        [ActionName("conta-desativada")]
        public virtual ActionResult ContaDesativada()
        {
            return View();
        }
        [ActionName("esqueci-minha-senha")]
        public virtual ActionResult EsqueciMinhaSenha()
        {
            return RedirectToAction(MVC.Home.Login());
        }

        [HttpPost, ActionName("esqueci-minha-senha")]
        public virtual ActionResult EsqueciMinhaSenha(string email)
        {
            var usuario = TClient.FindByEmail(email);
            if (usuario != null && usuario.IsActive)
            {
                //var passwordReset = TResetPassword.GenerateResetPassword(usuario);
                //Uri uri = Request.Url;
                //var link = string.Format("{0}://{1}/usuarios/nova-senha?token={2}", uri.Scheme, uri.Authority, passwordReset.Token);
                //passwordReset.UpdateLink(link);
                //try { new MailController().RecuperarSenha(passwordReset).Deliver(); } catch { }
                return Json(new { sucesso = "sucesso" }, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new { erro = "E-mail não encontrado ou conta desativada" }, JsonRequestBehavior.AllowGet);
        }

    }
}
