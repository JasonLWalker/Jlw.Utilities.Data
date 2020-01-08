
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
        /// Returns a DateTimeOffset object parsed from the input data, or Null is the input data is null, empty, DBNull, or cannot be parsed.
        /// </summary>
        /// <param name="obj">The object containing the data to parse.</param>
        /// <param name="key">The key to parse.</param>
        /// <returns>Returns a DateTimeOffset object, or Null is the data cannot be parsed.</returns>
        public static DateTimeOffset? ParseNullableDateTimeOffset(object obj, string key=null)
        {
            var data = GetObjectValue(obj, key);

            string s = (data ?? "").ToString().Trim();

            if (string.IsNullOrWhiteSpace(s) || data is DBNull)
                return null;

            if (data?.GetType() == typeof(DateTimeOffset))
                return (DateTimeOffset)data;

            DateTimeOffset dt;
            try
            {
                DateTimeOffset.TryParse(s, out dt);
                if (dt == DateTimeOffset.MinValue)
                    return null;

                return dt;
            }
            catch (IndexOutOfRangeException)
            {
                return null;
            }

        }

        public static DateTimeOffset ParseDateTimeOffset(object data, string key=null) => ParseNullableDateTimeOffset(data, key) ?? DateTimeOffset.MinValue;
    }
}
