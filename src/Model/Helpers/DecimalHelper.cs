using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Locadora.Domain;

namespace Locadora.Helpers
{
    public static class DecimalHelper
    {
        public static Decimal ConvertPercentageToDecimal(this Decimal percentage)
        {
            return percentage / 100;
        }

        public static Decimal GetPriceWithoutRounding(this Decimal number)
        {
            var splits = number.ToString().Replace(".","").Split(',');
            int getNumber = splits.Length > 1 && splits[1].Length == 1 ? 1 : 2;
            return splits.Length == 1 ? Decimal.Parse(splits[0]) : Decimal.Parse(splits[0] + ',' + splits[1].Substring(0, getNumber));
        }

        public static string GetMonthName(this int number)
        {
            var month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(number);
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(month.ToLower());
        }

        public static Decimal GetInstallmentsPayu(this decimal amountToPay, int installment)
        {
            var valueOrderWithCreditTax = GetTotalValuePayu(amountToPay, installment);
            return (installment == 1 ? amountToPay : valueOrderWithCreditTax / installment).GetPriceWithoutRounding();
        }

        public static Decimal GetTotalValuePayu(this decimal amountToPay, int installment)
        {
            if (installment == 1)
                return amountToPay;
            var valueOrderWithCreditTax = (amountToPay + (amountToPay * 0.0255m)).GetPriceWithoutRounding();
            decimal totalValue;
            if (installment == 2)
                totalValue = valueOrderWithCreditTax + amountToPay * 0.006m;
            else if (installment == 3)
                totalValue = valueOrderWithCreditTax + amountToPay * 0.008m;
            else if (installment == 4)
                totalValue = valueOrderWithCreditTax + amountToPay * 0.01m;
            else if (installment == 5)
                totalValue = valueOrderWithCreditTax + amountToPay * 0.012m;
            else
                totalValue = valueOrderWithCreditTax + amountToPay * 0.014m;
            return totalValue.GetPriceWithoutRounding();
        }

        public static Decimal CalculatePercentageToTimeLineAwards(this decimal vpp)
        {
            Decimal percentage = 0;
            var percentageFix = 12.5m;
            //var vpp = apuration.VppToTimeline;
            if (vpp < 50000)
                percentage = vpp / 50000 * 12.5m;
            else if (vpp < 150000)
            {
                vpp = vpp - 50000;
                percentage = 12.5m + (vpp / 100000 * percentageFix);
            }
            else if (vpp < 1000000)
            {
                vpp = vpp - 150000;
                percentage = 25m + (vpp / 850000 * percentageFix);
            }
            else if (vpp < 3000000)
            {
                vpp = vpp - 1000000;
                percentage = 37.5m + (vpp / 2000000 * percentageFix);
            }
            else if (vpp < 9000000)
            {
                vpp = vpp - 3000000;
                percentage = 50m + (vpp / 6000000 * percentageFix);
            }
            else if (vpp < 20000000)
            {
                vpp = vpp - 9000000;
                percentage = 62.5m + (vpp / 11000000 * percentageFix);
            }
            else if (vpp < 40000000)
            {
                vpp = vpp - 20000000;
                percentage = 75m + (vpp / 20000000 * percentageFix);
            }
            else if (vpp < 80000000)
            {
                vpp = vpp - 40000000;
                percentage = 87.5m + (vpp / 40000000 * percentageFix);
            }
            else
                percentage = 100;
            return percentage.GetPriceWithoutRounding();
        }
    }
}
