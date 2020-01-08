
// ReSharper disable once CheckNamespace

using System;
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


        /// <summary>
        /// Extracts the date as a string from a nullable <c>DateTime</c> object.
        /// Returns the date as a string in the MM/dd/yyyy format by default, but also supports custom dates via the format argument.
        /// </summary>
        /// <param name="dt">The nullable DateTime object to parse</param>
        /// <param name="format">The format to parse the date into. Defaults to "MM/dd/yyyy".</param>
        /// <returns>Returns the formatted date string, or an empty string if the <c>dt</c> parameter is <c>null</c>.</returns>
        public static string ExtractDate(DateTime? dt, string format = "MM/dd/yyyy")
        {
            if (dt == null)
                return "";

            return ((DateTime)dt).ToString(format);
        }

        /// <summary>
        /// Extracts the time as a string from a <c>nullable</c> DateTime object.
        /// Returns the time as a string in the h:mm tt format by default, but also supports custom dates via the format argument.
        /// </summary>
        /// <param name="dt">The nullable DateTime object to parse</param>
        /// <param name="format">The format to parse the date into.</param>
        /// <returns>Returns the formatted time string, or an empty string if the <c>dt</c> parameter is Null.</returns>
		public static string ExtractTime(DateTime? dt, string format = "h:mm tt")
        {
            if (dt == null)
                return "";

            return ((DateTime)dt).ToString(format);
        }

        /// <summary>
        /// Extracts the date suffix as a string from a <c>nullable</c> DateTime object.
        /// Returns a grammatically correct number suffix for the day value in the <c>dt</c> DateTime object as a string.
        /// </summary>
        /// <param name="dt">The nullable DateTime object to parse</param>
        /// <returns>Returns the number suffix for the day value, or an empty string if the <c>dt</c> parameter is Null.</returns>
        public static string ExtractDateSuffix(DateTime? dt)
        {
            if (dt == null)
                return "";

            switch (((DateTime)dt).Day)
            {
                case 1:
                case 21:
                case 31:
                    return "st";
                case 2:
                case 22:
                    return "nd";
                case 3:
                case 23:
                    return "rd";
            }
            return "th";
        }

        // Adapted from http://codebetter.com/petervanooijen/2005/09/26/iso-weeknumbers-of-a-date-a-c-implementation/
        /// <summary>
        /// Extracts the ISO 8601 week number from a <c>nullable</c> DateTime object. 
        /// Returns the ISO 8601 week number that should (hopefully) match the week number returned by the isoWeek function of the Moment.js library.
        /// </summary>
        /// <param name="date">The nullable DateTime object to parse</param>
        /// <returns>Returns the ISO 8601 week number, or an empty string if the <c>dt</c> parameter is Null.</returns>
        public static int ExtractISOWeekNumber(DateTime? date)
        {

            if (date == null)
                return 0;

            DateTime fromDate = (DateTime)date;

            // Get jan 1st of the year
            DateTime startOfYear = fromDate.AddDays(-fromDate.Day + 1).AddMonths(-fromDate.Month + 1);
            // Get dec 31st of the year
            DateTime endOfYear = startOfYear.AddYears(1).AddDays(-1);
            // ISO 8601 weeks start with Monday
            // The first week of a year includes the first Thursday
            // DayOfWeek returns 0 for Sunday up to 6 for Saturday
            int[] iso8601Correction = { 6, 7, 8, 9, 10, 4, 5 };
            int nds = fromDate.Subtract(startOfYear).Days + iso8601Correction[(int)startOfYear.DayOfWeek];
            int wk = nds / 7;
            switch (wk)
            {
                case 0:
                    // Return weeknumber of dec 31st of the previous year
                    return ExtractISOWeekNumber(startOfYear.AddDays(-1));
                case 53:
                    // If dec 31st falls before thursday it is week 01 of next year
                    if (endOfYear.DayOfWeek < DayOfWeek.Thursday)
                        return 1;
                    else
                        return wk;
                default: return wk;
            }
        }



    }
}
