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
    public partial class GenerosController : Controller
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

        protected ActionResult HandleViewException<T>(T model, SimpleValidationException ex)
        {
            ModelState.Clear();
            foreach (var item in ex.Errors)
                ModelState.AddModelError(item.PropertyName, item.Message);
            return View(model);
        }
    }
}