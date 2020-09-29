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
    public partial class GenerosController : BaseController
    {
        public virtual ActionResult Index()
        {
            var categoria = TCategory.ListAll().ToList();
            return View(categoria);
        }

        public virtual ActionResult Cadastrar()
        {
            var categoria = new TCategory();
            return View(categoria);
        }

        [HttpPost]
        public virtual ActionResult Cadastrar(TCategory model)
        {
            try
            {
                model.Save();
                TempData["Alerta"] = new Alert("success", "Seu gênero foi cadastrado com sucesso");
                return RedirectToAction("Index");
            }
            catch (SimpleValidationException ex)
            {
                return HandleViewException(model, ex);
            }
        }
        public virtual ActionResult Editar(int id)
        {
            var category = TCategory.Load(id);
            ViewBag.EnumProfileClient = EnumHelper.ListAll<ProfileClient>().ToSelectList(x => x, x => x.Description());
            return View(category);
        }
        [HttpPost]
        public virtual ActionResult Editar(TCategory model)
        {
            try
            {
                model.Update();
                TempData["Alerta"] = new Alert("success", "Seu gênero foi editado com sucesso");
                return RedirectToAction("Index");
            }
            catch (SimpleValidationException ex) 
            {
                return HandleViewException(model, ex);
            }
        }

        public virtual ActionResult Excluir(int id)
        {
            var category = TCategory.Load(id);
            return PartialView("_excluir", category);
        }

        [HttpPost]
        public virtual ActionResult Excluir(int id, object diff)
        {
            TCategory.Delete(id);
            return RedirectToAction("Index");
        }
    }
}