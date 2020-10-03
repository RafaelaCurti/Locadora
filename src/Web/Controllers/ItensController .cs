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
    public partial class ItensController : BaseController
    {
        public virtual ActionResult Index()
        {
            var itens = TIten.ListAll().ToList();
            return View(itens);
        }

        public virtual ActionResult Cadastrar()
        {
            var itens = new TIten();
            ViewBag.Reservation = TReservation.ListAll().ToSelectList(x => x.Id, x => x.Id);
            ViewBag.Movie = TMovie.ListAll().ToSelectList(x => x.Id, x => x.Id);
            return View();
        }

        [HttpPost]
        public virtual ActionResult Cadastrar(TIten model)
        {
            try
            {
                TempData["Alert"] = new Alert("success", "Seu item foi cadastrada com sucesso");
                model.Save();
                return RedirectToAction("Index");
            }
            catch (SimpleValidationException ex)
            {
                ViewBag.Reservation = TReservation.ListAll().ToSelectList(x => x.Id, x => x.Id);
                ViewBag.Movie = TMovie.ListAll().ToSelectList(x => x.Id, x => x.Id);
                return HandleViewException(model, ex);
            }
        }

        public virtual ActionResult Editar(int id)
        {
            var itens = new TIten();
            ViewBag.Reservation = TReservation.ListAll().ToSelectList(x => x.Id, x => x.Id);
            ViewBag.Movie = TMovie.ListAll().ToSelectList(x => x.Id, x => x.Id);
            return View();
        }

        [HttpPost]
        public virtual ActionResult Editar(TIten model)
        {
            try
            {
                TempData["Alert"] = new Alert("success", "Seu item foi editado com sucesso");
                model.Save();
                return RedirectToAction("Index");
            }
            catch (SimpleValidationException ex)
            {
                ViewBag.Reservation = TReservation.ListAll().ToSelectList(x => x.Id, x => x.Id);
                ViewBag.Movie = TMovie.ListAll().ToSelectList(x => x.Id, x => x.Id);
                return HandleViewException(model, ex);
            }
        }
        public virtual ActionResult ListarCliente(int id)
        {
            var reservation = TReservation.Load(id);
            return PartialView("_listar-reserva", reservation);
        }
        public virtual ActionResult ListarFilmes(int id)
        {
            var filme = TMovie.Load(id);
            return PartialView("_listar-filme", filme);
        }

        public virtual ActionResult Excluir(int id)
        {
            var iten = TIten.Load(id);
            return PartialView("_excluir", iten);
        }

        [HttpPost]
        public virtual ActionResult Excluir(int id, object diff)
        {
            TReservation.Delete(x => x.Id == id);
            TMovie.Delete(x => x.Id == id);
            TIten.Delete(id);
            return RedirectToAction("Index");

        }
    }
}