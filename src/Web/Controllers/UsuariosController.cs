using Locadora.Domain;
using Locadora.Helpers;
using Locadora.Web.Areas.Controllers;
using Simple.Validation;
using Simple.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Locadora.Web.Controllers
{
    public partial class UsuariosController : BaseController
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
                TempData["Alerta"] = new Alert("success", "Seu usuário foi cadastrado com sucessor");
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
                TempData["Alerta"] = new Alert("success", "Seu usuário foi editado com sucesso");
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


        public virtual ActionResult Login()
        {
            //var usuarios = TUser.Load(id);
            return View();
        }

        [HttpPost]
        public virtual ActionResult Login(string user, string password)
        {
            try
            {
                // código para verificar se o usuário existe e se a senha está correta!
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                // caso dê um erro fazer o que estiver aqui!
                return RedirectToAction("Login");
                throw;
            }
        }
    }
}