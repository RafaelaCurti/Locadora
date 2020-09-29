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
    public partial class UsuariosController : Controller
    {
        public virtual ActionResult Index()
        {
            var usuarios = TUser.ListAll().ToList();
            return View(usuarios);
        }

        public virtual ActionResult Cadastrar()
        {
            var usuarios = new TUser();
            ViewBag.MostraSenha = true;
            ViewBag.EnumProfileUser = EnumHelper.ListAll<ProfileUser>().ToSelectList(x => x, x => x.Description());
            return View(usuarios);
        }

        [HttpPost]
        public virtual ActionResult Cadastrar(TUser model)
        {
            try
            {
                model.Password = TUser.HashPassword(model.PasswordString);
                model.Save();
                return RedirectToAction("Index");
            }
            catch (SimpleValidationException ex)
            {
                ViewBag.MostraSenha = true;
                ViewBag.EnumProfileUser = EnumHelper.ListAll<ProfileUser>().ToSelectList(x => x, x => x.Description());
                return HandleViewException(model, ex);
            }
        }

        public virtual ActionResult Editar(int id)
        {
            var usuarios = TUser.Load(id);
            ViewBag.MostraSenha = false;
            ViewBag.EnumProfileUser = EnumHelper.ListAll<ProfileUser>().ToSelectList(x => x, x => x.Description());
            return View(usuarios);
        }

        [HttpPost]
        public virtual ActionResult Editar(TUser model)
        {
            try
            {
                model.Edit();
                return RedirectToAction("Index");
            }
            catch (SimpleValidationException ex)
            {
                ViewBag.MostraSenha = false;
                ViewBag.EnumProfileUser = EnumHelper.ListAll<ProfileUser>().ToSelectList(x => x, x => x.Description());
                return HandleViewException(model, ex);
            }
        }
        public virtual ActionResult Excluir(int id)
        {
            var usuarios = TUser.Load(id);
            return PartialView("_excluir", usuarios);
        }

        [HttpPost]
        public virtual ActionResult Excluir(int id, object diff)
        {
            TUser.Delete(id);
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