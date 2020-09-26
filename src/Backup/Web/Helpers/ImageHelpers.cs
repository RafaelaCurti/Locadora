using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Locadora.Domain;
using System.Drawing.Imaging;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Locadora.Web.Helpers
{
    public static class ImageHelpers
    {
        public static byte[] ResizeImage(this byte[] image, ImageSize size, ImageFormat format)
        {
            var img = image.ToImage();
            if (img == null) return image;

            img.Dispose();

            return image;
        }

        private static byte[] ExtractByteArray(this Image thumb, Image img, ImageFormat format)
        {
            MemoryStream result = new MemoryStream();
            thumb.Save(result, format ?? img.RawFormat);

            byte[] array = result.GetBuffer();
            Array.Resize(ref array, (int)result.Length);
            return array;
        }

        private static Graphics CreateGraphicPort(this Image thumb)
        {
            Graphics graphic = Graphics.FromImage(thumb);
            graphic.CompositingQuality = CompositingQuality.HighQuality;
            graphic.SmoothingMode = SmoothingMode.HighQuality;
            graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
            return graphic;
        }

        private static Image CreateOutputImage(this Image img, float newH, float newW)
        {
            var pixelFormat = img.PixelFormat;
            if ((pixelFormat & PixelFormat.Indexed) != 0) pixelFormat = PixelFormat.Format64bppPArgb;
            Image thumb = new Bitmap((int)newW, (int)newH, pixelFormat);
            return thumb;
        }

        private static float CalculateNewDimension(this int size, float prop)
        {
            return (float)Math.Round(size / prop);
        }

        private static Image ToImage(this byte[] image)
        {
            Image img = null;
            try
            {
                img = Image.FromStream(new MemoryStream(image));
            }
            catch (ArgumentException) { }
            return img;
        }
    }
}
