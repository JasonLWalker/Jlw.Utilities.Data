
// ReSharper disable once CheckNamespace

using System.Text;
using System.Text.RegularExpressions;

namespace Jlw.Standard.Utilities.Data
{
    public partial class DataUtility
    {
        private static Regex _rxPhone = new Regex(@"^\s*\(?\s*(\d{3})\s*\)?\s*[-]?\s*(\d{3})\s*[-]?\s*(\d{4})\s*$");

        /// <summary>
        /// Extracts the number suffix as a string from an input object of any type.
        /// Returns a grammatically correct number suffix for the parsed number as a string.
        /// </summary>
        /// <param name="n">The object to parse</param>
        /// <returns>Returns the number suffix parsed value, or an empty string if the <c>n</c> parameter is <c>null</c>.</returns>
        public static string GetNumberSuffix(object n)
        {
            string s = ParseInt(n).ToString();
            if (s == "0")
                return "";

            char c = s[s.Length - 1];
            switch (c)
            {
                case '1':
                    if (s.Length > 1 && s.EndsWith("11"))
                        s = "th";
                    else
                        s = "st";
                    break;
                case '2':
                    if (s.Length > 1 && s.EndsWith("12"))
                        s = "th";
                    else
                        s = "nd";
                    break;
                case '3':
                    if (s.Length > 1 && s.EndsWith("13"))
                        s = "th";
                    else
                        s = "rd";
                    break;
                default:
                    s = "th";
                    break;
            }
            return s;
        }

        /// <summary>
        /// Sets the first character of every word in the string to uppercase.
        /// </summary>
        /// <param name="s">The string to operate on.</param>
        /// <returns>Returns a copy of the input string with the 1st character of all of the words uppercase.</returns>
        public static string UcWords(string s)
        {
            return Regex.Replace(s, @"\b[a-z]\w+", match => { var v = match.ToString(); return char.ToUpper(v[0]) + v.Substring(1); });
        }

        public static string FormatPhone(string s, string format = "($1) $2-$3")
        {
            return _rxPhone.Replace(s, format);
        }

        protected static string ExtractNumericString(string data)
        {
            var sb = new StringBuilder();

            foreach (var c in data)
            {
                if (c == '.' || c == '-' || (c >= '0' && c <= '9'))
                    sb.Append(c);
            }

            return sb.ToString();
        }


    }
}
