using Locadora.Domain;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace Locadora.Helpers
{
    public static class StringHelper
    {
        public static string LimitSize(this string str, int size)
        {
            if (string.IsNullOrWhiteSpace(str))
                return string.Empty;
            if (str.Length <= size)
                return str;
            return str.Substring(0, size - 1);
        }

        public static string InitialLetters(this string str, int size)
        {
            if (string.IsNullOrWhiteSpace(str)) return string.Empty;
            str = Regex.Replace(str, @"<[^>]*>", String.Empty);
            return string.Format("{0}", str.Substring(0, size));
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

        public static string RemoveSpecialCaracteres(this string str)
        {
            if (string.IsNullOrWhiteSpace(str)) return "";

            str = str.Replace(".", "");
            str = str.Replace("-", "");
            str = str.Replace("/", "");
            str = str.Replace("(", "");
            str = str.Replace(")", "");
            return str;
        }

        public static string RemoveDotApostrophe(this string str)
        {
            if (string.IsNullOrWhiteSpace(str)) return "";

            str = str.Trim();
            str = str.Replace("'", "");
            str = str.Replace("`", "");
            str = str.Replace("´", "");
            return str;
        }

        public static string RemoveAccent(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return String.Empty;

            StringBuilder sbReturn = new StringBuilder();
            var arrayText = str.Trim().Normalize(NormalizationForm.FormD).ToCharArray();
            foreach (char letter in arrayText)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                    sbReturn.Append(letter);
            }
            return sbReturn.ToString();
        }

        public static string ToPlural(this string str, int quantity)
        {
            if (quantity > 1)
            {
                if (str.EndsWith("m"))
                    return string.Format("{0}ns", str.Substring(0, str.Length - 1));
                else if (str.EndsWith("ão"))
                    return string.Format("{0}ões", str.Substring(0, str.Length - 2));
                else if (str.EndsWith("á"))
                    return string.Format("{0}ão", str.Substring(0, str.Length - 1));
                else if (str.EndsWith("el") || str.EndsWith("il"))
                    return string.Format("{0}eis", str.Substring(0, str.Length - 2));
                else if (str.EndsWith("or"))
                    return string.Format("{0}es", str);
                else if (str.EndsWith("ês"))
                    return string.Format("{0}es", str.RemoveAccent());
                else
                    return string.Format("{0}s", str);
            }
            else
                return str;
        }

        public static string NoneOrNumber(this int quantity)
        {
            if (quantity > 0)
                return quantity.ToString(CultureInfo.InvariantCulture);
            else
                return "Nenhum";
        }

        public static string NotSpecifiedOrNumber(this decimal quantity)
        {
            if (quantity > 0)
                return IntegerOrDecimal(quantity);
            else
                return "Não especificado";
        }

        public static string NotSpecifiedOrNumberInCentimetersOrGrams(this decimal quantity, string measure)
        {
            if (quantity > 0)
                return string.Format("{0} {1}", IntegerOrDecimal(quantity), measure);
            else
                return "Não especificado";
        }

        public static bool Contains(this string source, string toCheck, StringComparison comp)
        {
            if (string.IsNullOrWhiteSpace(source)) return false;
            return source.IndexOf(toCheck, comp) >= 0;
        }

        public static string FormDecimal(this decimal str)
        {
            if (str > 0)
                return String.Format("{0:C}", str);
            else
                return String.Format("{0:C}", 0);
        }

        public static string ToRealMoney(this decimal str)
        {
            if (str == decimal.MinValue)
                return "Consulte-nos";
            if (str == decimal.MaxValue)
                return "Indisponível";

            var nfi = (NumberFormatInfo)CultureInfo.CurrentCulture.NumberFormat.Clone();
            nfi.CurrencySymbol = "R$";
            return String.Format(nfi, "{0:C}", str);
        }

        public static string ToDollarMoney(this decimal str)
        {
            var nfi = (NumberFormatInfo)CultureInfo.CurrentCulture.NumberFormat.Clone();
            nfi.CurrencySymbol = "U$";
            return String.Format(nfi, "{0:C2}", str > 0 ? str : 0);
        }

        public static string ToPercent(this decimal str, int precision = 2)
        {
            return str > 0 ? (str / 100).ToString(string.Format("P{0}", precision)) : str.ToString("P");
        }

        public static string RemoveHTMLTags(this string str)
        {
            return Regex.Replace(str, "<.*?>", string.Empty);
        }

        public static bool IsEmail(this string emailAddress)
        {
            var match = Regex.Match(emailAddress, @"^[a-z0-9]+[a-z0-9._%+-]+[a-z0-9]+@[a-z0-9.-]+\.[a-z]{2,4}$");
            return match.Success;
        }

        public static bool IsCpf(this string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
                return false;

            if (cpf == "00000000000" || cpf == "11111111111" || cpf == "22222222222" || cpf == "33333333333" || cpf == "44444444444" ||
                cpf == "55555555555" || cpf == "66666666666" || cpf == "77777777777" || cpf == "88888888888" || cpf == "99999999999")
                return false;

            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();

            tempCpf = tempCpf + digito;

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);
        }

        public static bool IsCnpj(this string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;

            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");

            if (cnpj.Length != 14)
                return false;

            tempCnpj = cnpj.Substring(0, 12);

            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();

            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cnpj.EndsWith(digito);
        }

        public static bool IsPis(string pis)
        {
            int[] multiplicador = new int[10] { 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;

            if (pis.Trim().Length != 11)
                return false;

            pis = pis.Trim();
            pis = pis.Replace("-", "").Replace(".", "").PadLeft(11, '0');


            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(pis[i].ToString()) * multiplicador[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            return pis.EndsWith(resto.ToString());
        }

        public static string CreateRandomPassword(int passwordLength)
        {
            string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789!@$?_-";
            char[] chars = new char[passwordLength];
            Random rd = new Random();

            for (int i = 0; i < passwordLength; i++)
            {
                chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
            }

            return new string(chars);
        }

        public static string CreateRandomAlphaNumeric(int length)
        {
            string allowedChars = "ABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";
            char[] chars = new char[length];
            Random rd = new Random();
            for (int i = 0; i < length; i++)
            {
                chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
            }
            return new string(chars);
        }

        public static string ReplaceDotToComma(this decimal str)
        {
            return string.Format("{0:0.00}", str).Replace('.', ',');
        }

        public static string ReplaceCommaToDot(this decimal str)
        {
            return string.Format("{0:0.00}", str).Replace(',', '.');
        }

        public static string ToMeters(this decimal str)
        {
            return string.Format("{0:0.00}m", str);
        }

        public static string ToKilograms(this decimal str)
        {
            return string.Format("{0:0.00}kg", str);
        }

        public static string ToMD5(this string input)
        {
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);
            md5.Dispose();
            var sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
                sb.Append(hash[i].ToString("X2"));
            return sb.ToString().ToLower();
        }

        public static string RemoveExtraZerosAndSignals(this decimal str)
        {
            var split = str.ToString().Split(',');
            if (split.Count() == 1)
                return str.ToString();
            var last = split.LastOrDefault().Substring(0, 2);
            return string.Format("{0}{1}", split.FirstOrDefault().Replace(".", ""), last);
        }

        public static string RemoveExtraZerosWithFormatting(this decimal str)
        {
            var split = str.ToString("F2").Split(',');
            if (split.Count() == 1)
                return str.ToString();
            var last = split.LastOrDefault().Substring(0, 2);
            return string.Format("{0}{1}", split.FirstOrDefault().Replace(".", ""), last);
        }

        public static string PointsInThousands(this decimal str, bool comma = true)
        {
            return String.Format(CultureInfo.GetCultureInfo(comma ? "pt-BR" : "en-US"), str >= 1000 ? "{0:0,00.00}" : "{0:0.00}", Math.Truncate(str * 100) / 100);
        }

        public static string IntegerOrDecimal(this decimal number)
        {
            if (number == 0)
                return "0";
            int numberInt = (int)number;
            return String.Format("{0:0,0.##}", number);
        }

        public static string AddExtraZeros(this int number, int totalSize)
        {
            return number.ToString("D" + totalSize.ToString());
        }

        public static string CompleteEmptySpace(this string str, int size)
        {
            int length = string.IsNullOrWhiteSpace(str) ? 0 : str.Length;

            if (length > size)
                return string.Format("{0}", str.Substring(0, size - 1));

            string spaces = String.Empty;
            for (int i = 0; i < (size - length); i++)
            {
                spaces = spaces + " ";
            }
            return string.Format("{0}{1}", str, spaces);
        }

        public static string CompleteWithZero(this string str, int size)
        {
            str = str.Replace(",", "").Replace(".", "");

            int length = string.IsNullOrWhiteSpace(str) ? 0 : str.Length;

            if (length > size)
                return string.Format("{0}", str.Substring(0, size - 1));

            string spaces = String.Empty;
            for (int i = 0; i < (size - length); i++)
            {
                spaces = "0" + spaces;
            }
            return string.Format("{0}{1}", spaces, str);

        }

        public static string NameForPagSeguro(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return String.Empty;
            str = str.Replace('&', 'E');
            str = str.RemoveEmptySpaceBetweenNames();
            return str;
        }

        public static string NameForS3Amazon(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return String.Empty;

            str = str.Replace(" ", "-");
            str = str.Replace("+", "-");
            return str;
        }

        public static string RemoveEmptySpaceBetweenNames(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return String.Empty;

            var name = String.Empty;
            var splits = str.Trim().Split(' ');
            for (var i = 0; i < splits.Length; i++)
            {
                if (splits[i].Length > 0)
                    name = name + splits[i] + " ";
            }
            return name.TrimEnd();
        }

        public static string PriceFormatWithDot(this decimal str)
        {
            return str.ToString("F2").Replace(",", ".");
        }

        public static string PriceFormatWithoutDot(this decimal str)
        {
            return str.ToString("F2").Replace(",", "").Replace(".", "");
        }

        public static string GetAreaCodeNumberPhone(this string str)
        {
            str = str.Trim();
            str = str.Replace("+", "");
            if (str.Contains(')'))
            {
                var code = str.Split(')').FirstOrDefault().Replace("(", "").Substring(0, 2);
                return code.Length > 2 ? code.Substring(1, 2) : code;
            }
            else
                return str.Substring(str.StartsWith("0") ? 1 : 0, 2);
        }

        public static string GetOnlyNumberPhone(this string str)
        {
            if (str.Contains(')'))
            {
                var phone = str.Split(')').LastOrDefault().Trim().RemoveSpecialCaracteres();
                return phone.Length > 9 ? phone.Substring(0, 9) : phone;
            }
            else if (str.Contains(' '))
                return str.Substring(str.StartsWith("0") ? 4 : 3, 8);
            else
                return str.Substring(str.StartsWith("0") ? 3 : 2, 8);
        }

        public static string GetNumberAddress(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return "S/N";
            return str.Trim();
        }

        public static string GetComplementAddress(this string str)
        {
            if (string.IsNullOrWhiteSpace(str)) return string.Empty;
            str = str.RemoveEmptySpaceBetweenNames();
            if (str.Length <= 20) return str;
            return str.Substring(0, 20);
        }

        public static string GetStringOrNotSpecified(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return "NÃO INFORMADO";
            return str.Trim();
        }

        public static string GetZipcodeAddress(this string str)
        {
            return str.Trim().Replace("-", "").Replace(".", "").Replace(" ", "");
        }

        public static string GetPersonDocument(this string str)
        {
            return str.Trim().Replace(".", "").Replace("-", "").Replace("/", "").Replace(" ", "");
        }

        public static string MaskNumberCard(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return String.Empty;

            var splits = str.Split(' ');
            if (splits.Length < 4)
                return str;
            else
                return string.Format("{0} **** **** {1}", splits.First(), splits.Last());

        }

        public static string GetCpfFormatted(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return String.Empty;

            if (str.Length == 11 && !str.Contains('.'))
                return string.Format("{0}.{1}.{2}-{3}", str.Substring(0, 3), str.Substring(3, 3), str.Substring(6, 3), str.Substring(9, 2));
            return str;
        }

        public static string GetCnpjFormatted(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return String.Empty;

            if (str.Length == 14 && !str.Contains('.'))
                return string.Format("{0}.{1}.{2}/{3}-{4}", str.Substring(0, 2), str.Substring(2, 3), str.Substring(5, 3), str.Substring(8, 4), str.Substring(12, 2));
            return str;
        }

        public static string RemoveInitialZero(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return String.Empty;
            if (str.StartsWith("0"))
                return str.Substring(1, str.Length - 1);
            return str;
        }

        public static string WriteTraceIfNull(this string str)
        {
            if (string.IsNullOrWhiteSpace(str)) return "-";
            return str;
        }

        public static MvcHtmlString YesOrNo(this bool check)
        {
            return new MvcHtmlString(check ? "<i class='fas fa-check' style='color:green'></i>" : "<i class='fas fa-times' style='color:red'></i>");
        }

        public static MvcHtmlString YesOrNo(this string check)
        {
            return new MvcHtmlString(check == "S" || check == "s" ? "<i class='fas fa-check' style='color:green'></i>" : "<i class='fas fa-times' style='color:red'></i>");
        }

        public static String IconByTypeFile(this string ext)
        {
            if (ext.Contains("jpg") || ext.Contains("jpeg") || ext.Contains("png") || ext.Contains("tif"))
                return "fa-image blue";
            else if (ext.Contains("doc"))
                return "fa-file-word blue";
            else if (ext.Contains("xls"))
                return "fa-file-excel green";
            else if (ext.Contains("ppt") || ext.Contains("pps"))
                return "fa-file-powerpoint red";
            else if (ext.Contains("pdf"))
                return "fa-file-pdf red";
            else if (ext.Contains("txt"))
                return "fa-file-alt black";
            else if (ext.Contains("zip"))
                return "fa-archive black";
            return "fa-paperclip black";
        }

        public static string GetFormatValidAgainstSqlinjection(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return str;
            str = str.Replace("'", "''");
            str = str.Replace("--", " ");
            str = str.Replace("/*", " ");
            str = str.Replace("*/", " ");
            str = str.Replace(" or ", "");
            str = str.Replace(" and ", "");
            str = str.Replace("update", "");
            str = str.Replace("-shutdown", "");
            str = str.Replace("--", "");
            str = str.Replace("'or'1'='1'", "");
            str = str.Replace("insert", "");
            str = str.Replace("drop", "");
            str = str.Replace("delete", "");
            str = str.Replace("xp_", "");
            str = str.Replace("sp_", "");
            str = str.Replace("select", "");
            str = str.Replace("1 union select", "");
            return str;
        }

        public static List<string> ListDomainsEmail(this string email)
        {
            var emails = new List<String>();
            var domains = new string[] { "gmail.com", "yahoo.com", "yahoo.com.br", "hotmail.com", "hotmail.com.br", "outlook.com", "icloud.com" };
            var split = email.Split('@');
            var loginEmail = split.First();
            var domainEmail = split.Last();
            foreach (var item in domains)
            {
                if (string.IsNullOrWhiteSpace(domainEmail) || item.StartsWith(domainEmail))
                    emails.Add(string.Format("{0}@{1}", loginEmail, item));
            }
            return emails;
        }
    }
}
