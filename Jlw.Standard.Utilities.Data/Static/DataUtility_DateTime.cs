
// ReSharper disable once CheckNamespace

using System;
using System.Collections.Generic;
using System.Data;

namespace Jlw.Standard.Utilities.Data
{
    public partial class DataUtility
    {
        /// <summary>
        /// Parses a <c>nullable</c> DateTime object from an input object of any type.
        /// Returns a DateTime object parsed from the input data, or Null is the input data is null, empty, DBNull, or cannot be parsed.
        /// </summary>
        /// <param name="obj">The object containing the data to parse.</param>
        /// <param name="key">The key to parse.</param>
        /// <returns>Returns a DateTime object, or Null is the data cannot be parsed.</returns>
        public static DateTime? ParseNullableDateTime(object obj, string key = null)
        {
            var data = GetObjectValue(obj, key);

            string s = (data ?? "").ToString().Trim();

            if (string.IsNullOrWhiteSpace(s) || data is DBNull)
                return null;

            //DateTime dt = ParseDateTime(data);
            if (data?.GetType() == typeof(DateTime))
                return (DateTime)data;

            try
            {
                DateTime dt;
                DateTime.TryParse(s, out dt);
                return dt;
            }
            catch (IndexOutOfRangeException)
            {
                return null;
            }
        }


        public static DateTime ParseDateTime(object obj, string key = null) => ParseNullableDateTime(obj, key) ?? DateTime.MinValue;

    }
}
