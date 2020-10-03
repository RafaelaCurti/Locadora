// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments and CLS compliance
// 0108: suppress "Foo hides inherited member Foo. Use the new keyword if hiding was intended." when a controller and its abstract parent are both processed
// 0114: suppress "Foo.BarController.Baz()' hides inherited member 'Qux.BarController.Baz()'. To make the current member override that implementation, add the override keyword. Otherwise add the new keyword." when an action (with an argument) overrides an action in a parent controller
#pragma warning disable 1591, 3008, 3009, 0108, 0114
#region T4MVC

using System;
using System.Diagnostics;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using T4MVC;
namespace Locadora.Web.Controllers
{
    public partial class ReservasController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ReservasController() { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected ReservasController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(Task<ActionResult> taskResult)
        {
            return RedirectToAction(taskResult.Result);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoutePermanent(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(Task<ActionResult> taskResult)
        {
            return RedirectToActionPermanent(taskResult.Result);
        }

        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult Editar()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Editar);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult ListarCliente()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ListarCliente);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult ListarFilmes()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ListarFilmes);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult Excluir()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Excluir);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ReservasController Actions { get { return MVC.Reservas; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "Reservas";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "Reservas";
        [GeneratedCode("T4MVC", "2.0")]
        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string Index = "Index";
            public readonly string Cadastrar = "Cadastrar";
            public readonly string Editar = "Editar";
            public readonly string ListarCliente = "ListarCliente";
            public readonly string ListarFilmes = "ListarFilmes";
            public readonly string Excluir = "Excluir";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string Index = "Index";
            public const string Cadastrar = "Cadastrar";
            public const string Editar = "Editar";
            public const string ListarCliente = "ListarCliente";
            public const string ListarFilmes = "ListarFilmes";
            public const string Excluir = "Excluir";
        }


        static readonly ActionParamsClass_Cadastrar s_params_Cadastrar = new ActionParamsClass_Cadastrar();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Cadastrar CadastrarParams { get { return s_params_Cadastrar; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Cadastrar
        {
            public readonly string model = "model";
        }
        static readonly ActionParamsClass_Editar s_params_Editar = new ActionParamsClass_Editar();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Editar EditarParams { get { return s_params_Editar; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Editar
        {
            public readonly string id = "id";
            public readonly string model = "model";
        }
        static readonly ActionParamsClass_ListarCliente s_params_ListarCliente = new ActionParamsClass_ListarCliente();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_ListarCliente ListarClienteParams { get { return s_params_ListarCliente; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_ListarCliente
        {
            public readonly string id = "id";
        }
        static readonly ActionParamsClass_ListarFilmes s_params_ListarFilmes = new ActionParamsClass_ListarFilmes();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_ListarFilmes ListarFilmesParams { get { return s_params_ListarFilmes; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_ListarFilmes
        {
            public readonly string id = "id";
        }
        static readonly ActionParamsClass_Excluir s_params_Excluir = new ActionParamsClass_Excluir();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Excluir ExcluirParams { get { return s_params_Excluir; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Excluir
        {
            public readonly string id = "id";
            public readonly string diff = "diff";
        }
        static readonly ViewsClass s_views = new ViewsClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewsClass Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewsClass
        {
            static readonly _ViewNamesClass s_ViewNames = new _ViewNamesClass();
            public _ViewNamesClass ViewNames { get { return s_ViewNames; } }
            public class _ViewNamesClass
            {
                public readonly string _excluir = "_excluir";
                public readonly string _form = "_form";
                public readonly string _listar_cliente = "_listar-cliente";
                public readonly string _listar_filmes = "_listar-filmes";
                public readonly string _listar_reserva = "_listar-reserva";
                public readonly string cadastrar = "cadastrar";
                public readonly string editar = "editar";
                public readonly string Index = "Index";
            }
            public readonly string _excluir = "~/Views/Reservas/_excluir.cshtml";
            public readonly string _form = "~/Views/Reservas/_form.cshtml";
            public readonly string _listar_cliente = "~/Views/Reservas/_listar-cliente.cshtml";
            public readonly string _listar_filmes = "~/Views/Reservas/_listar-filmes.cshtml";
            public readonly string _listar_reserva = "~/Views/Reservas/_listar-reserva.cshtml";
            public readonly string cadastrar = "~/Views/Reservas/cadastrar.cshtml";
            public readonly string editar = "~/Views/Reservas/editar.cshtml";
            public readonly string Index = "~/Views/Reservas/Index.cshtml";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_ReservasController : Locadora.Web.Controllers.ReservasController
    {
        public T4MVC_ReservasController() : base(Dummy.Instance) { }

        [NonAction]
        partial void IndexOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult Index()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Index);
            IndexOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void CadastrarOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult Cadastrar()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Cadastrar);
            CadastrarOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void CadastrarOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, Locadora.Domain.TReservation model);

        [NonAction]
        public override System.Web.Mvc.ActionResult Cadastrar(Locadora.Domain.TReservation model)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Cadastrar);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "model", model);
            CadastrarOverride(callInfo, model);
            return callInfo;
        }

        [NonAction]
        partial void EditarOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int id);

        [NonAction]
        public override System.Web.Mvc.ActionResult Editar(int id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Editar);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            EditarOverride(callInfo, id);
            return callInfo;
        }

        [NonAction]
        partial void EditarOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, Locadora.Domain.TReservation model);

        [NonAction]
        public override System.Web.Mvc.ActionResult Editar(Locadora.Domain.TReservation model)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Editar);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "model", model);
            EditarOverride(callInfo, model);
            return callInfo;
        }

        [NonAction]
        partial void ListarClienteOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int id);

        [NonAction]
        public override System.Web.Mvc.ActionResult ListarCliente(int id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ListarCliente);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            ListarClienteOverride(callInfo, id);
            return callInfo;
        }

        [NonAction]
        partial void ListarFilmesOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int id);

        [NonAction]
        public override System.Web.Mvc.ActionResult ListarFilmes(int id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ListarFilmes);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            ListarFilmesOverride(callInfo, id);
            return callInfo;
        }

        [NonAction]
        partial void ExcluirOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int id);

        [NonAction]
        public override System.Web.Mvc.ActionResult Excluir(int id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Excluir);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            ExcluirOverride(callInfo, id);
            return callInfo;
        }

        [NonAction]
        partial void ExcluirOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int id, object diff);

        [NonAction]
        public override System.Web.Mvc.ActionResult Excluir(int id, object diff)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Excluir);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "diff", diff);
            ExcluirOverride(callInfo, id, diff);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591, 3008, 3009, 0108, 0114
