using Locadora.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Locadora.Helpers
{
    public static class DateTimeHelper
    {
        public static DateTime GetCurrent(this DateTime dateTime)
        {
            return TimeZoneInfo.ConvertTimeBySystemTimeZoneId(dateTime, "E. South America Standard Time");
        }

        public static string FormattedName(this DateTime dateTime)
        {
            if (dateTime != null && dateTime != DateTime.MinValue && dateTime != DateTime.MaxValue)
                return string.Format("{0:dd} de {0:MMMM} de {0:yyyy}", dateTime);
            else
                return "";
        }

        public static string ToForm(this DateTime dateTime)
        {
            if (dateTime != null && dateTime != DateTime.MinValue && dateTime != DateTime.MaxValue)
                return string.Format("{0:dd/MM/yyyy}", dateTime);
            else
                return "";
        }

        public static string FormattedNameWithHours(this DateTime dateTime)
        {
            if (dateTime != null && dateTime != DateTime.MinValue && dateTime != DateTime.MaxValue)
                return string.Format("{0:dd/MM/yyyy} às {0:HH:mm:ss}", dateTime);
            else
                return "";
        }

        public static string ToISO8601(this DateTime dateTime)
        {
            if (dateTime != null && dateTime != DateTime.MinValue && dateTime != DateTime.MaxValue)
                return string.Format("{0:yyyy-MM-ddTHH:mm:ssZ}", dateTime.ToUniversalTime());
            else
                return "";
        }
        
        public static string ToISO8859(this DateTime dateTime)
        {
            if (dateTime != null && dateTime != DateTime.MinValue && dateTime != DateTime.MaxValue)
                return string.Format("{0:yyyy-MM-ddTHH:mm}", dateTime);
            else
                return "";
        }

        public static string DayMonthAndYear(this DateTime dateTime)
        {
            if (dateTime != null && dateTime != DateTime.MinValue && dateTime != DateTime.MaxValue)
                return string.Format("{0:dd/MM/yyyy}", dateTime);
            else
                return "Não definida";
        }

        public static string DynamicTime(this DateTime dateTime)
        {
            if (dateTime != null && dateTime != DateTime.MinValue && dateTime != DateTime.MaxValue)
            {
                var now = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, "E. South America Standard Time");
                TimeSpan diff = now.Subtract(dateTime);
                if (diff.TotalDays >= 1 || dateTime.DayOfYear != now.DayOfYear)
                    return string.Format("{0:dd/MM/yyyy}", dateTime);
                else if (dateTime.DayOfYear == now.DayOfYear)
                    return string.Format("{0:HH:mm}", dateTime);
                else
                    return string.Format("Há {0} minutos", diff.Minutes);
            }
            else
                return "";
        }

        public static bool IsValid(this DateTime dateTime)
        {
            if (dateTime != null && dateTime != DateTime.MinValue && dateTime != DateTime.MaxValue)
                return true;
            else
                return false;
        }

        public static string RemainingTime(this DateTime dateTime, bool complete = true)
        {
            var remainingFinal = new StringBuilder();
            var remaining = dateTime.Subtract(DateTime.Now.GetCurrent());
            if (remaining.Days > 0)
                remainingFinal.AppendFormat("{0} dias", remaining.Days);
            else
            {
                if (remaining.Hours > 0)
                {
                    remainingFinal.AppendFormat("{0}h", remaining.Hours);
                    if (remaining.Minutes > 0)
                        remainingFinal.AppendFormat("{0}m", remaining.Minutes);
                }
                else if (remaining.Minutes > 0)
                    remainingFinal.AppendFormat("{0}m", remaining.Minutes);
                else
                    remainingFinal.AppendFormat("{0}s", remaining.Seconds);
                if (complete == true)
                {
                    if (remaining.Seconds > 0)
                        remainingFinal.AppendFormat("{0}s", remaining.Seconds);
                }
            }

            return remainingFinal.ToString();
        }

        public static string DayMonthAndYearWithHours(this DateTime dateTime)
        {
            if (dateTime != null && dateTime != DateTime.MinValue && dateTime != DateTime.MaxValue)
                return string.Format("{0:dd/MM/yyyy HH:mm:ss}", dateTime);
            else
                return "Não definida";
        }

        public static string DefaultFormat(this DateTime dateTime)
        {
            if (dateTime != null && dateTime != DateTime.MinValue && dateTime != DateTime.MaxValue)
                return string.Format("{0:yyyy/MM/dd HH:mm:ss}", dateTime);
            else
                return "";
        }

        public static DateTime ToInitialDate(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0);
        }

        public static DateTime ToEndDate(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 23, 59, 59);
        }

        public static DateTime MinDateBySearch(this DateTime dateTime)
        {
            return new DateTime(1900, 1, 1, 0, 0, 0);
        }

        public static DateTime MaxDateBySearch(this DateTime dateTime)
        {
            return new DateTime(3000, 12, 31, 23, 59, 59);
        }
        
        public static string PublicationTime(this DateTime date)
        {
            var elapsedTime = DateTime.Now.GetCurrent().Subtract(date);
            if (elapsedTime.TotalMinutes < 1)
                return string.Format("{0} {1} atrás", elapsedTime.Seconds, "segundo".ToPlural(elapsedTime.Seconds));
            else if (elapsedTime.TotalHours < 1)
                return string.Format("{0} {1} atrás", elapsedTime.Minutes, "minuto".ToPlural(elapsedTime.Minutes));
            else if (elapsedTime.TotalDays < 1)
                return string.Format("{0} {1} atrás", elapsedTime.Hours, "hora".ToPlural(elapsedTime.Hours));
            else if (elapsedTime.TotalDays < 31)
                return string.Format("{0} {1} atrás", elapsedTime.Days, "dia".ToPlural(elapsedTime.Days));
            else if (elapsedTime.TotalDays > 30 && elapsedTime.TotalDays < 366)
                return string.Format("{0} {1} atrás", ((int)elapsedTime.Days / 31), "mês".ToPlural((int)elapsedTime.Days / 31));
            else if (elapsedTime.TotalDays > 365)
                return string.Format("{0} {1} atrás", ((int)elapsedTime.Days / 365), "ano".ToPlural((int)elapsedTime.Days / 365));
            else
                return "não estimado";
        }

        public static MvcHtmlString ListYears(this DateTime dateTime)
        {
            var sb = new StringBuilder();
            for (int i = 2017; i <= dateTime.Year; i++)
            {
                var selected = dateTime.Year == i ? "selected" : String.Empty;
                sb.Append(String.Format("<option value='{0}' {1}>{0}</option>", i, selected));
            }
            return new MvcHtmlString(sb.ToString());
        }

        public static MvcHtmlString ListYearsWithoutSelected(this DateTime dateTime)
        {
            var sb = new StringBuilder();
            sb.Append("<option value=''>Selecione uma opção</option>");
            for (int i = 2017; i <= dateTime.Year; i++)
                sb.Append(String.Format("<option value='{0}'>{0}</option>", i));
            return new MvcHtmlString(sb.ToString());
        }

        public static MvcHtmlString ListYearsWithSelected(this DateTime dateTime, int value)
        {
            var sb = new StringBuilder();
            var selected = String.Empty;
            sb.Append("<option value=''>Selecione uma opção</option>");
            for (int i = 2017; i <= dateTime.Year; i++)
            {
                selected = value == i ? "selected" : String.Empty;
                sb.Append(String.Format("<option value='{0}' {1}>{0}</option>", i, selected));
            }
            return new MvcHtmlString(sb.ToString());
        }

        public static MvcHtmlString ListMonths(this DateTime dateTime)
        {
            var meses = EnumHelper.ListAll<Month>();
            var sb = new StringBuilder();
            foreach (var mes in meses)
            {
                var selected = dateTime.Month == (int)mes ? "selected" : String.Empty;
                sb.Append(String.Format("<option value='{0}' {1}>{2}</option>", (int)mes, selected, mes.Description()));
            }
            return new MvcHtmlString(sb.ToString());
        }

        public static MvcHtmlString ListMonthsWithoutSelected(this DateTime dateTime)
        {
            var meses = EnumHelper.ListAll<Month>();
            var sb = new StringBuilder();
            sb.Append("<option value=''>Selecione uma opção</option>");
            foreach (var mes in meses)
                sb.Append(String.Format("<option value='{0}'>{1}</option>", (int)mes, mes.Description()));
            return new MvcHtmlString(sb.ToString());
        }

        public static MvcHtmlString ListMonthsWithSelected(this DateTime dateTime, int value)
        {
            var meses = EnumHelper.ListAll<Month>();
            var sb = new StringBuilder();
            var selected = String.Empty;
            foreach (var mes in meses)
            {
                selected = value == (int)mes ? "selected" : String.Empty;
                sb.Append(String.Format("<option value='{0}' {1}>{2}</option>", (int)mes, selected, mes.Description()));
            }
            return new MvcHtmlString(sb.ToString());
        }

        public static DateTime AddBusinessDays(this DateTime dt, int nDays)
        {
            int weeks = nDays / 5;
            nDays %= 5;
            while (dt.DayOfWeek == DayOfWeek.Saturday || dt.DayOfWeek == DayOfWeek.Sunday)
                dt = dt.AddDays(1);
            while (nDays-- > 0)
            {
                dt = dt.AddDays(1);
                if (dt.DayOfWeek == DayOfWeek.Saturday)
                    dt = dt.AddDays(2);
            }
            return dt.AddDays(weeks * 7);
        }

        public static MvcHtmlString ListYearsToValidateCreditCard(this DateTime dateTime)
        {
            var sb = new StringBuilder();
            sb.Append("<option value=''>Ano</option>");
            var endYear = dateTime.AddYears(15).Year;
            for (int i = dateTime.Year; i <= endYear; i++)
                sb.Append(String.Format("<option value='{0}'>{0}</option>", i));
            return new MvcHtmlString(sb.ToString());
        }

        public static MvcHtmlString ListMonthsToValidateCreditCard(this DateTime dateTime)
        {
            var meses = EnumHelper.ListAll<Month>();
            var sb = new StringBuilder();
            sb.Append("<option value=''>Mês</option>");
            foreach (var mes in meses)
                sb.Append(String.Format("<option value='{0}'>{0}</option>", ((int)mes).AddExtraZeros(2)));
            return new MvcHtmlString(sb.ToString());
        }
    }
}
