using Locadora.Domain;
using Locadora.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Globalization;
using System.Web.Mvc;

namespace Locadora.Web.Helpers
{
    public static class ClientHelper
    {
        //public static MvcHtmlString GetImgQualification(decimal? qualification)
        //{
        //    if (!qualification.HasValue)
        //        return new MvcHtmlString("<i class='fas fa-user-tie fa-7x'></i>");
        //    var urlImage = qualification == 10 ? Links.Content.images.pin.pin_elite_png :
        //        qualification == 15 ? Links.Content.images.pin.pin_safira_png :
        //        qualification == 20 ? Links.Content.images.pin.pin_rubi_png :
        //        qualification == 25 ? Links.Content.images.pin.pin_esmeralda_png :
        //        qualification == 30 ? Links.Content.images.pin.pin_diamante_png :
        //        qualification == 35 ? Links.Content.images.pin.pin_blue_diamond_png :
        //        qualification == 40 ? Links.Content.images.pin.pin_red_diamond_png :
        //        qualification == 45 ? Links.Content.images.pin.pin_black_diamond_png :
        //        qualification == 50 ? Links.Content.images.pin.pin_imperial_diamond_png :
        //        qualification == 55 ? Links.Content.images.pin.pin_crown_png :
        //        qualification == 60 ? Links.Content.images.pin.pin_royal_png :
        //        qualification == 65 ? Links.Content.images.pin.pin_chanceler_png :
        //        string.Empty;
        //    var tag = string.IsNullOrWhiteSpace(urlImage) ? "<i class='fas fa-user-tie fa-7x'></i>" : string.Format("<img src='{0}' alt='qualificação' />", urlImage);
        //    return new MvcHtmlString(tag);
        //}

        //public static MvcHtmlString GetImgPack(TProduct produto)
        //{
        //    if (produto == null)
        //        return new MvcHtmlString("<i class='fas fa-shopping-bag fa-7x'></i>");
        //    var url = produto.GetImageProductDefault();
        //    if (url.Contains("padrao"))
        //        return new MvcHtmlString("<i class='fas fa-shopping-bag fa-7x'></i>");
        //    return new MvcHtmlString(string.Format("<img src='{0}' alt='{1}' style='width: 92px; height: 92px; border: 1px solid #aaa' />", url, produto.Name));
        //}

        //public static String GetImage(this string str)
        //{
        //    return string.IsNullOrWhiteSpace(str) ? Links.Content.images.usuario_jpg : AmazonService.GetSignedUrl(str);
        //}

        public static Subdomain GetSubdomain(this string url)
        {
            if (url.Contains("painel."))
                return Subdomain.Painel;
            else if (url.Contains("pdv."))
                return Subdomain.PDV;
            else if (url.Contains("loja."))
                return Subdomain.Store;
            else if (url.Contains("ev."))
                return Subdomain.Backoffice;
            else
                return Subdomain.Register;
        }
    }
}