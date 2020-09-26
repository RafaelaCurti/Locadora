using Locadora.Domain;
using Locadora.Helpers;
using Simple.Validation;
using Simple.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Locadora.Web.Controllers
{
    public partial class ClientesController : Controller
    {
        public virtual ActionResult Index()
        {
            var clientes = TClient.ListAll().ToList();
            return View(clientes);
        }

        public virtual ActionResult Cadastrar()
        {
            var cliente = new TClient();
            ViewBag.MostraSenha = true;
            ViewBag.EnumProfileClient = EnumHelper.ListAll<ProfileClient>().ToSelectList(x => x, x => x.Description());
            ViewBag.Category = TPreference.ListAll().ToSelectList(x => x.Id, x => x.Name);
            return View(cliente);
        }

        [HttpPost]
        public virtual ActionResult Cadastrar(TClient model)
        {
            try
            {
                model.Password = TClient.HashPassword(model.PasswordString);
                ViewBag.TPreferences.SaveCategories(model);
                model.Save();
                return RedirectToAction("Index");
            }
            catch (SimpleValidationException ex)
            {
                ViewBag.MostraSenha = true;
                ViewBag.EnumProfileClient = EnumHelper.ListAll<ProfileClient>().ToSelectList(x => x, x => x.Description());
                return HandleViewException(model, ex);
            }
        }

        public virtual ActionResult Editar(int id)
        {
            var cliente = TClient.Load(id);
            ViewBag.MostraSenha = false;
            ViewBag.EnumProfileClient = EnumHelper.ListAll<ProfileClient>().ToSelectList(x => x, x => x.Description());
            ViewBag.TPreferences.SaveCategories(cliente);
            return View(cliente);
        }

        [HttpPost]
        public virtual ActionResult Editar(TClient model)
        {
            try
            {
                model.Update();
                model.Edit();
                ViewBag.TPreferences.SaveCategories(model);
                return RedirectToAction("Index");
            }
            catch (SimpleValidationException ex)
            {
                ViewBag.MostraSenha = false;
                ViewBag.EnumProfileClient = EnumHelper.ListAll<ProfileClient>().ToSelectList(x => x, x => x.Description());
                return HandleViewException(model, ex);
            }
        }

        public virtual ActionResult Excluir(int id)
        {
            var cliente = TClient.Load(id);
            return PartialView("_excluir", cliente);
        }

        [HttpPost]
        public virtual ActionResult Excluir(int id, object diff)
        {
            TClient.Delete(id);
            return RedirectToAction("Index");
        }

        protected ActionResult HandleViewException<T>(T model, SimpleValidationException ex)
        {
            ModelState.Clear();
            foreach (var item in ex.Errors)
                ModelState.AddModelError(item.PropertyName, item.Message);
            return View(model);
        }
    }
}