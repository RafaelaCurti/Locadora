using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text.RegularExpressions;
using System.Text;

namespace Locadora.Web.Helpers
{
    public static class StringHelper
    {
        public static string LimitSize(this string str, int size)
        {
            if (string.IsNullOrWhiteSpace(str)) return string.Empty;

            str = Regex.Replace(str, @"<[^>]*>", String.Empty);

            if ((size - 4) <= 0) return str;
            if (str.Length <= size - 4) return str;

            return string.Format("{0} ...", str.Substring(0, size - 4));

        }

        public static string FriendlyName(this string str)
        {
            if (string.IsNullOrWhiteSpace(str)) return "";

            str = str.ToLower();
            str = Encoding.ASCII.GetString(Encoding.GetEncoding(1251).GetBytes(str));
            str = Regex.Replace(str, @"&\w+;", "");
            str = Regex.Replace(str, @"[^a-z0-9\-\s]", "");
            str = str.Replace(' ', '-');
            str = Regex.Replace(str, @"-{2,}", "-");
            str = str.TrimStart(new[] { '-' });
            str = str.TrimEnd(new[] { '-' });

            return str;
        }

        public static string RemoveHtmlTags(this string str)
        {
            if (string.IsNullOrWhiteSpace(str)) return string.Empty;

            str = Regex.Replace(str, @"[\r\n]+", string.Empty);
            return Regex.Replace(str, @"<(.|\n)*?>", string.Empty);
        }
    }
}
