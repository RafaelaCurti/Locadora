﻿// <auto-generated />
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

[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
public static partial class MVC
{
    public static Locadora.Web.Controllers.ClientesController Clientes = new Locadora.Web.Controllers.T4MVC_ClientesController();
    public static Locadora.Web.Controllers.FilmesController Filmes = new Locadora.Web.Controllers.T4MVC_FilmesController();
    public static Locadora.Web.Controllers.GenerosController Generos = new Locadora.Web.Controllers.T4MVC_GenerosController();
    public static Locadora.Web.Controllers.HomeController Home = new Locadora.Web.Controllers.T4MVC_HomeController();
    public static Locadora.Web.Controllers.MailController Mail = new Locadora.Web.Controllers.T4MVC_MailController();
    public static Locadora.Web.Controllers.SystemController System = new Locadora.Web.Controllers.T4MVC_SystemController();
    public static Locadora.Web.Controllers.UsuariosController Usuarios = new Locadora.Web.Controllers.T4MVC_UsuariosController();
    public static T4MVC.SharedController Shared = new T4MVC.SharedController();
}

namespace T4MVC
{
}

#pragma warning disable 0436
namespace T4MVC
{
    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public class Dummy
    {
        private Dummy() { }
        public static Dummy Instance = new Dummy();
    }
}
#pragma warning restore 0436

[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
internal partial class T4MVC_System_Web_Mvc_ActionResult : System.Web.Mvc.ActionResult, IT4MVCActionResult
{
    public T4MVC_System_Web_Mvc_ActionResult(string area, string controller, string action, string protocol = null): base()
    {
        this.InitMVCT4Result(area, controller, action, protocol);
    }
     
    public override void ExecuteResult(System.Web.Mvc.ControllerContext context) { }
    
    public string Controller { get; set; }
    public string Action { get; set; }
    public string Protocol { get; set; }
    public RouteValueDictionary RouteValueDictionary { get; set; }
}
[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
internal partial class T4MVC_ActionMailer_Net_Mvc_EmailResult : ActionMailer.Net.Mvc.EmailResult, IT4MVCActionResult
{
    public T4MVC_ActionMailer_Net_Mvc_EmailResult(string area, string controller, string action, string protocol = null): base(default(ActionMailer.Net.IMailInterceptor), default(ActionMailer.Net.IMailSender), default(System.Net.Mail.MailMessage), " ", " ", default(System.Text.Encoding), default(bool))
    {
        this.InitMVCT4Result(area, controller, action, protocol);
    }
    
    public string Controller { get; set; }
    public string Action { get; set; }
    public string Protocol { get; set; }
    public RouteValueDictionary RouteValueDictionary { get; set; }
}



namespace Links
{
    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public static class Scripts {
        public const string UrlPath = "~/Scripts";
        public static string Url() { return T4MVCHelpers.ProcessVirtualPath(UrlPath); }
        public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(UrlPath + "/" + fileName); }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public static class bootstrap {
            public const string UrlPath = "~/Scripts/bootstrap";
            public static string Url() { return T4MVCHelpers.ProcessVirtualPath(UrlPath); }
            public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(UrlPath + "/" + fileName); }
            public static readonly string alert_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/alert.min.js") ? Url("alert.min.js") : Url("alert.js");
            public static readonly string bootstrap_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/bootstrap.min.js") ? Url("bootstrap.min.js") : Url("bootstrap.js");
            public static readonly string bootstrap_min_js = Url("bootstrap.min.js");
            public static readonly string button_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/button.min.js") ? Url("button.min.js") : Url("button.js");
            public static readonly string carousel_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/carousel.min.js") ? Url("carousel.min.js") : Url("carousel.js");
            public static readonly string collapse_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/collapse.min.js") ? Url("collapse.min.js") : Url("collapse.js");
            public static readonly string dropdown_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/dropdown.min.js") ? Url("dropdown.min.js") : Url("dropdown.js");
            public static readonly string modal_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/modal.min.js") ? Url("modal.min.js") : Url("modal.js");
            public static readonly string popover_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/popover.min.js") ? Url("popover.min.js") : Url("popover.js");
            public static readonly string scrollspy_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/scrollspy.min.js") ? Url("scrollspy.min.js") : Url("scrollspy.js");
            public static readonly string tab_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/tab.min.js") ? Url("tab.min.js") : Url("tab.js");
            public static readonly string tooltip_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/tooltip.min.js") ? Url("tooltip.min.js") : Url("tooltip.js");
            public static readonly string transition_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/transition.min.js") ? Url("transition.min.js") : Url("transition.js");
            public static readonly string typeahead_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/typeahead.min.js") ? Url("typeahead.min.js") : Url("typeahead.js");
        }
    
        public static readonly string jquery_1_7_2_min_js = Url("jquery-1.7.2.min.js");
        public static readonly string jquery_livequery_min_js = Url("jquery.livequery.min.js");
        public static readonly string jquery_validate_min_js = Url("jquery.validate.min.js");
        public static readonly string master_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/master.min.js") ? Url("master.min.js") : Url("master.js");
        public static readonly string messages_pt_br_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/messages_pt_br.min.js") ? Url("messages_pt_br.min.js") : Url("messages_pt_br.js");
        public static readonly string modernizr_2_5_3_respond_1_1_0_min_js = Url("modernizr-2.5.3-respond-1.1.0.min.js");
        public static readonly string plugins_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/plugins.min.js") ? Url("plugins.min.js") : Url("plugins.js");
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public static class Content {
        public const string UrlPath = "~/Content";
        public static string Url() { return T4MVCHelpers.ProcessVirtualPath(UrlPath); }
        public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(UrlPath + "/" + fileName); }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public static class bootstrap {
            public const string UrlPath = "~/Content/bootstrap";
            public static string Url() { return T4MVCHelpers.ProcessVirtualPath(UrlPath); }
            public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(UrlPath + "/" + fileName); }
            public static readonly string bootstrap_responsive2_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/bootstrap-responsive2.min.css") ? Url("bootstrap-responsive2.min.css") : Url("bootstrap-responsive2.css");
            public static readonly string bootstrap_theme_min_css = Url("bootstrap-theme.min.css");
            public static readonly string bootstrap_min_css = Url("bootstrap.min.css");
            public static readonly string bootstrap2_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/bootstrap2.min.css") ? Url("bootstrap2.min.css") : Url("bootstrap2.css");
            public static readonly string bootstrap2_min_css = Url("bootstrap2.min.css");
        }
    
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public static class css {
            public const string UrlPath = "~/Content/css";
            public static string Url() { return T4MVCHelpers.ProcessVirtualPath(UrlPath); }
            public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(UrlPath + "/" + fileName); }
            public static readonly string style_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/style.min.css") ? Url("style.min.css") : Url("style.css");
        }
    
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public static class fonts {
            public const string UrlPath = "~/Content/fonts";
            public static string Url() { return T4MVCHelpers.ProcessVirtualPath(UrlPath); }
            public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(UrlPath + "/" + fileName); }
            public static readonly string glyphicons_halflings_regular_eot = Url("glyphicons-halflings-regular.eot");
            public static readonly string glyphicons_halflings_regular_svg = Url("glyphicons-halflings-regular.svg");
            public static readonly string glyphicons_halflings_regular_ttf = Url("glyphicons-halflings-regular.ttf");
            public static readonly string glyphicons_halflings_regular_woff = Url("glyphicons-halflings-regular.woff");
            public static readonly string glyphicons_halflings_regular_woff2 = Url("glyphicons-halflings-regular.woff2");
        }
    
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public static class img {
            public const string UrlPath = "~/Content/img";
            public static string Url() { return T4MVCHelpers.ProcessVirtualPath(UrlPath); }
            public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(UrlPath + "/" + fileName); }
            public static readonly string glyphicons_halflings_white_png = Url("glyphicons-halflings-white.png");
            public static readonly string glyphicons_halflings_png = Url("glyphicons-halflings.png");
        }
    
    }

    
    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public static partial class Bundles
    {
        public static partial class Scripts 
        {
            public static partial class bootstrap 
            {
                public static class Assets
                {
                    public static readonly string alert_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/bootstrap/alert.js"); 
                    public static readonly string bootstrap_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/bootstrap/bootstrap.js"); 
                    public static readonly string bootstrap_min_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/bootstrap/bootstrap.min.js"); 
                    public static readonly string button_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/bootstrap/button.js"); 
                    public static readonly string carousel_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/bootstrap/carousel.js"); 
                    public static readonly string collapse_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/bootstrap/collapse.js"); 
                    public static readonly string dropdown_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/bootstrap/dropdown.js"); 
                    public static readonly string modal_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/bootstrap/modal.js"); 
                    public static readonly string popover_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/bootstrap/popover.js"); 
                    public static readonly string scrollspy_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/bootstrap/scrollspy.js"); 
                    public static readonly string tab_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/bootstrap/tab.js"); 
                    public static readonly string tooltip_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/bootstrap/tooltip.js"); 
                    public static readonly string transition_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/bootstrap/transition.js"); 
                    public static readonly string typeahead_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/bootstrap/typeahead.js"); 
                }
            }
            public static class Assets
            {
                public static readonly string jquery_1_7_2_min_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/jquery-1.7.2.min.js"); 
                public static readonly string jquery_livequery_min_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/jquery.livequery.min.js"); 
                public static readonly string jquery_validate_min_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/jquery.validate.min.js"); 
                public static readonly string master_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/master.js"); 
                public static readonly string messages_pt_br_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/messages_pt_br.js"); 
                public static readonly string modernizr_2_5_3_respond_1_1_0_min_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/modernizr-2.5.3-respond-1.1.0.min.js"); 
                public static readonly string plugins_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/plugins.js"); 
            }
        }
        public static partial class Content 
        {
            public static partial class bootstrap 
            {
                public static class Assets
                {
                    public static readonly string bootstrap_responsive2_css = T4MVCHelpers.ProcessAssetPath("~/Content/bootstrap/bootstrap-responsive2.css");
                    public static readonly string bootstrap_theme_min_css = T4MVCHelpers.ProcessAssetPath("~/Content/bootstrap/bootstrap-theme.min.css");
                    public static readonly string bootstrap_min_css = T4MVCHelpers.ProcessAssetPath("~/Content/bootstrap/bootstrap.min.css");
                    public static readonly string bootstrap2_css = T4MVCHelpers.ProcessAssetPath("~/Content/bootstrap/bootstrap2.css");
                    public static readonly string bootstrap2_min_css = T4MVCHelpers.ProcessAssetPath("~/Content/bootstrap/bootstrap2.min.css");
                }
            }
            public static partial class css 
            {
                public static class Assets
                {
                    public static readonly string style_css = T4MVCHelpers.ProcessAssetPath("~/Content/css/style.css");
                }
            }
            public static partial class fonts 
            {
                public static class Assets
                {
                }
            }
            public static partial class img 
            {
                public static class Assets
                {
                }
            }
            public static class Assets
            {
            }
        }
    }
}

[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
internal static class T4MVCHelpers {
    // You can change the ProcessVirtualPath method to modify the path that gets returned to the client.
    // e.g. you can prepend a domain, or append a query string:
    //      return "http://localhost" + path + "?foo=bar";
    private static string ProcessVirtualPathDefault(string virtualPath) {
        // The path that comes in starts with ~/ and must first be made absolute
        string path = VirtualPathUtility.ToAbsolute(virtualPath);
        
        // Add your own modifications here before returning the path
        return path;
    }

    private static string ProcessAssetPathDefault(string virtualPath) {
        // The path that comes in starts with ~/ and should retain this prefix
        return virtualPath;
    }

    // Calling ProcessVirtualPath through delegate to allow it to be replaced for unit testing
    public static Func<string, string> ProcessVirtualPath = ProcessVirtualPathDefault;
    public static Func<string, string> ProcessAssetPath = ProcessAssetPathDefault;

    // Calling T4Extension.TimestampString through delegate to allow it to be replaced for unit testing and other purposes
    public static Func<string, string> TimestampString = System.Web.Mvc.T4Extensions.TimestampString;

    // Logic to determine if the app is running in production or dev environment
    public static bool IsProduction() { 
        return (HttpContext.Current != null && !HttpContext.Current.IsDebuggingEnabled); 
    }
}





#endregion T4MVC
#pragma warning restore 1591, 3008, 3009, 0108, 0114


