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
    public partial class FilmesController : Controller
    {
        public virtual ActionResult Index()
        {
            var filmes = TMovie.ListAll().ToList();
            return View(filmes);
            //var filmes2 = TMovieCategory.List(x => x.Category.Id == 5).Select(x => x.Movie);
            //TClient.List(x => x.Name == "Pedro");
            //TClient.List(x => x.Name.StartsWith("m"));
            //TClient.List(x => x.Name.EndsWith("l"));
            //TClient.List(x => x.Name.Contains("silva"));
            //TReservation.List(x => x.Client.Name.StartsWith("p"));
            //TUser.Delete(x => x.Name.EndsWith("u"));
            //TClient.Delete(x => x.Name.StartsWith("pedro") || x.Name.EndsWith("silva"));
            //TClient.List(x => Name.StartsWith("Maria") && Name.EndsWith("João"));
            //TReservation.Delete(x => x.Client.Id == cliente.Id);
            //TPreference.Delete(x => x.Client.Name.Contains("João"));
            //TMovie.List(x => x.IsActive && x.Stock > 0);
        }

        public virtual ActionResult Cadastrar()
        {
            var filme = new TMovie();
            ViewBag.EnumFormatMovie = EnumHelper.ListAll<FormatMovie>().ToSelectList(x => x, x => x.Description());
            ViewBag.EnumTypeMovie = EnumHelper.ListAll<TypeMovie>().ToSelectList(x => x, x => x.Description());
            ViewBag.Category = TCategory.ListAll().ToSelectList(x => x.Id, x => x.Name);
            return View(filme);
        }

        [HttpPost]
        public virtual ActionResult Cadastrar(TMovie model)
        {
            try
            {
                model.Date = DateTime.Now.GetCurrent();
                model.Save();
                TMovieCategory.SaveCategories(model);
                return RedirectToAction("Index");
            }
            catch (SimpleValidationException ex)
            {
                ViewBag.EnumFormatMovie = EnumHelper.ListAll<FormatMovie>().ToSelectList(x => x, x => x.Description());
                ViewBag.EnumTypeMovie = EnumHelper.ListAll<TypeMovie>().ToSelectList(x => x, x => x.Description());
                return HandleViewException(model, ex);
            }
        }

        public virtual ActionResult Editar(int id)
        {
            var filme = TMovie.Load(id);
            var categoriasFilme = filme.TMovieCategories.Select(x => x.Category.Id).ToList();
            ViewBag.EnumFormatMovie = EnumHelper.ListAll<FormatMovie>().ToSelectList(x => x, x => x.Description());
            ViewBag.EnumTypeMovie = EnumHelper.ListAll<TypeMovie>().ToSelectList(x => x, x => x.Description());
            ViewBag.Category = TCategory.List(x => !categoriasFilme.Contains(x.Id)).ToSelectList(x => x.Id, x => x.Name);
            return View(filme);
        }

        [HttpPost]
        public virtual ActionResult Editar(TMovie model)
        {
            model.Update();
            TMovieCategory.SaveCategories(model);
            return RedirectToAction("Index");
        }

        public virtual ActionResult ListarGenero(int id)
        {
            var genero = TCategory.Load(id);
            return PartialView("_listar-genero", genero);
        }

        public virtual ActionResult Excluir(int id)
        {
            var filme = TMovie.Load(id);
            return PartialView("_excluir", filme);
        }

        [HttpPost]
        public virtual ActionResult Excluir(int id, object diff)
        {
            TMovieCategory.Delete(x => x.Movie.Id == id);
            TMovie.Delete(id);
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