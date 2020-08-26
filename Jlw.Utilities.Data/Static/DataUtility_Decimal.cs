
// ReSharper disable once CheckNamespace

using System;
using System.Collections.Generic;
using System.Data;

namespace Jlw.Utilities.Data
{
    public partial class DataUtility
    {
        /// <summary>
        /// Parses a decimal value from an input object of any type.
        /// </summary>
        /// <param name="obj">The object containing the data to parse.</param>
        /// <param name="key">The key to parse.</param>
        /// <returns>Returns the value, or <c>0.0M</c> if the data cannot be parsed.</returns>
        public static decimal ParseDecimal(object obj, string key = null) => ParseNullableDecimal(obj, key) ?? 0.0M;


        /// <summary>
        /// Parses a decimal value from an input object of any type.
        /// </summary>
        /// <param name="obj">The object containing the data to parse.</param>
        /// <param name="key">The key to parse.</param>
        /// <returns>Returns the value, or <c>null</c> if the data cannot be parsed.</returns>
        public static decimal? ParseNullableDecimal(object obj, string key=null)
        {
            var data = GetObjectValue(obj, key);

            if (data == null || data is DBNull)
                return null;
            try
            {
                decimal.TryParse(data.ToString().Trim(), out var d);
                return d;
            }
            catch (OverflowException) { }
            return null;
        }


    }
}
