using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Locadora.Web.Helpers
{
    public static class ImageResultHelper
    {
        public static ImageResult Image(this Controller controller, byte[] imageData, string mimeType)
        {
            return new ImageResult
            {
                ImageData = imageData,
                MimeType = mimeType
            };
        }

        public static ImageResult Image(this Controller controller, byte[] imageData, string mimeType, HttpCacheability cacheability, DateTime expires, string eTag)
        {
            return new ImageResult
            {
                ImageData = imageData,
                MimeType = mimeType,
                Cacheability = cacheability,
                Expires = expires,
                ETag = eTag
            };
        }
    }

    public class ImageResult : ActionResult
    {
        public ImageResult()
        {
        }

        public byte[] ImageData
        {
            get;
            set;
        }

        public string MimeType
        {
            get;
            set;
        }

        public HttpCacheability Cacheability
        {
            get;
            set;
        }

        public string ETag
        {
            get;
            set;
        }

        public DateTime? Expires
        {
            get;
            set;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            if (this.ImageData == null)
            {
                throw new ArgumentNullException("ImageData");
            }

            if (string.IsNullOrEmpty(this.MimeType))
            {
                throw new ArgumentNullException("MimeType");
            }

            context.HttpContext.Response.ContentType = this.MimeType;

            if (!string.IsNullOrEmpty(this.ETag))
            {
                context.HttpContext.Response.Cache.SetETag(this.ETag);
            }

            if (this.Expires.HasValue)
            {
                context.HttpContext.Response.Cache.SetCacheability(this.Cacheability);
                context.HttpContext.Response.Cache.SetExpires(this.Expires.Value);
            }

            context.HttpContext.Response.OutputStream.Write(this.ImageData, 0, this.ImageData.Length);
        }
    }
}
