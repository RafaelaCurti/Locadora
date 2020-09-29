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
    public partial class ClientesController : BaseController
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
            ViewBag.Genero = TMovieCategory.ListAll().ToSelectList(x => x.Category.Id, x => x.Category.Name);
            return View(cliente);
        }

        [HttpPost]
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

        public virtual ActionResult Editar(int id)
        {
            var cliente = TClient.Load(id);
            ViewBag.MostraSenha = false;
            ViewBag.EnumProfileClient = EnumHelper.ListAll<ProfileClient>().ToSelectList(x => x, x => x.Description());
            ViewBag.Genero = TMovieCategory.ListAll().ToSelectList(x => x.Category.Id, x => x.Category.Name);
            return View(cliente);
        }

        [HttpPost]
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
                return HandleViewException (model, ex);
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
    }
}