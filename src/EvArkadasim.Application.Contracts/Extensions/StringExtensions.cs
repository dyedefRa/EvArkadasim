using System;
using System.Linq;

namespace EvArkadasim.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// wwwroot alanını kaldırır.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToFileShownPath(this string value)
        {
            return value.Replace("wwwroot", "");
        }

        public static bool IsValidTcNumber(this string value)
        {
            bool returnvalue = false;

            if (value.Length == 11 && value.All(char.IsDigit))
            {
                Int64 ATCNO, BTCNO, TcNo;
                long C1, C2, C3, C4, C5, C6, C7, C8, C9, Q1, Q2;

                TcNo = Int64.Parse(value);

                ATCNO = TcNo / 100;
                BTCNO = TcNo / 100;

                C1 = ATCNO % 10; ATCNO = ATCNO / 10;
                C2 = ATCNO % 10; ATCNO = ATCNO / 10;
                C3 = ATCNO % 10; ATCNO = ATCNO / 10;
                C4 = ATCNO % 10; ATCNO = ATCNO / 10;
                C5 = ATCNO % 10; ATCNO = ATCNO / 10;
                C6 = ATCNO % 10; ATCNO = ATCNO / 10;
                C7 = ATCNO % 10; ATCNO = ATCNO / 10;
                C8 = ATCNO % 10; ATCNO = ATCNO / 10;
                C9 = ATCNO % 10; ATCNO = ATCNO / 10;
                Q1 = ((10 - ((((C1 + C3 + C5 + C7 + C9) * 3) + (C2 + C4 + C6 + C8)) % 10)) % 10);
                Q2 = ((10 - (((((C2 + C4 + C6 + C8) + Q1) * 3) + (C1 + C3 + C5 + C7 + C9)) % 10)) % 10);

                returnvalue = ((BTCNO * 100) + (Q1 * 10) + Q2 == TcNo);
            }

            return returnvalue;
        }

        public static string ToCamelCase(this string value)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return char.ToLowerInvariant(value[0]) + value.Substring(1);
        }

        public static string ApplyShortening(this string value, int maxLength = 1000)
        {
            if (string.IsNullOrEmpty(value))
                return "";
            else if (value.Length < maxLength)
            {
                return value;
            }

            return value.Substring(0, maxLength) + " ...";
        }

        public static string ToAllDateString(this DateTime value)
        {
            return value.ToString("MM/dd/yyyy HH:mm");
        }
    }
}
