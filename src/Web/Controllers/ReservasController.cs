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
    public partial class ReservasController : BaseController
    {
        public virtual ActionResult Index()
        {
            var reserva = TReservation.ListAll().ToList();
            return View(reserva);
        }

        public virtual ActionResult Cadastrar()
        {
            var reserva = new TReservation();
            ViewBag.Client = TClient.ListAll().ToSelectList(x => x.Id, x => x.Name);
            ViewBag.Iten = TMovie.ListAll().ToSelectList(x => x.Id, x => x.Name);
            ViewBag.Sale = TSale.ListAll().ToSelectList(x => x.Id, x => x.EnumStatusSale);
            //ViewBag.Movie = TMovie.ListAll().ToSelectList(x => x.Id, x => x.Name);
            return View();
        }

        [HttpPost]
        public virtual ActionResult Cadastrar(TReservation model)
        {
            try
            {
                TempData["Alert"] = new Alert("success", "Sua reserva foi cadastrada com sucesso");
                model.Save();
                return RedirectToAction("Index");
            }
            catch (SimpleValidationException ex)
            {
                ViewBag.Client = TClient.ListAll().ToSelectList(x => x.Id, x => x.Name);
                ViewBag.Itens = TIten.ListAll().ToSelectList(x => x.Id, x => x.Movie);
                return HandleViewException(model, ex);
            }
        }

        public virtual ActionResult Editar(int id)
        {
            var reserva = new TReservation();
            ViewBag.Client = TClient.ListAll().ToSelectList(x => x.Id, x => x.Name);
            ViewBag.Iten = TMovie.ListAll().ToSelectList(x => x.Id, x => x.Name);
            ViewBag.Sale = TSale.ListAll().ToSelectList(x => x.Id, x => x.EnumStatusSale);
            return View();
        }

        [HttpPost]
        public virtual ActionResult Editar(TReservation model)
        {
            try
            {
                TempData["Alert"] = new Alert("success", "Sua reserva foi editada com sucesso");
                model.Save();
                return RedirectToAction("Index");
            }
            catch (SimpleValidationException ex)
            {
                ViewBag.Client = TClient.ListAll().ToSelectList(x => x.Id, x => x.Name);
                ViewBag.Itens = TIten.ListAll().ToSelectList(x => x.Id, x => x.Movie);
                return HandleViewException(model, ex);
            }
        }

        public virtual ActionResult ListarCliente(int id)
        {
            var cliente = TClient.Load(id);
            return PartialView("_listar-cliente", cliente);
        }
        public virtual ActionResult ListarFilmes(int id)
        {
            var filme = TMovie.Load(id);
            return PartialView("_listar-filme", filme);
        }

        public virtual ActionResult Excluir(int id)
        {
            var reserva = TReservation.Load(id);
            return PartialView("_excluir", reserva);
        }

        [HttpPost]
        public virtual ActionResult Excluir(int id, object diff)
        {
            TClient.Delete(x => x.Id == id);
            TIten.Delete(x => x.Id == id);
            TReservation.Delete(id);
            return RedirectToAction("Index");

        }
    }
}