
// ReSharper disable once CheckNamespace

using System;
using System.Collections.Generic;
using System.Data;

namespace Jlw.Standard.Utilities.Data
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
        /*
        {
            try
            {
                decimal.TryParse((data ?? "").ToString().Trim(), out var d);
                return d;
            }
            catch (OverflowException) { }
           
            return 0.0M;
        }
        */
        /*
        /// <summary>
        /// Parses a decimal value from an object that implements the <c>IDataRecord</c> interface.
        /// This includes SqlDataReader and other inherited SQL Data records.
        /// </summary>
        /// <param name="o">The IDataRecord object containing the key to parse.</param>
        /// <param name="key">The key of the data to parse.</param>
        /// <returns>Returns the value, or <c>0.0M</c> if the data cannot be parsed.</returns>
        public static decimal ParseDecimal(IDataRecord o, string key)
        {
            try
            {
                return ParseDecimal(o?[key]);
            }
            catch (IndexOutOfRangeException) { }
            return 0.0M;
        }

        /// <summary>
        /// Parses a decimal value from an object that implements the <c>IDictionary&lt;string, object&gt;</c> interface.
        /// </summary>
        /// <param name="o">The IDictionary object containing the key to parse.</param>
        /// <param name="key">The key of the data to parse.</param>
        /// <returns>Returns the value, or <c>0.0M</c> if the data cannot be parsed.</returns>
        public static decimal ParseDecimal(IDictionary<string, object> o, string key)
        {
            try
            {
                return ParseDecimal(o?[key]);
            }
            catch (IndexOutOfRangeException) { }
            return 0.0M;
        }
        */

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

        /*
        /// <summary>
        /// Parses a decimal value from an object that implements the <c>IDataRecord</c> interface.
        /// This includes SqlDataReader and other inherited SQL Data records.
        /// </summary>
        /// <param name="o">The IDataRecord object containing the key to parse.</param>
        /// <param name="key">The key of the data to parse.</param>
        /// <returns>Returns the value, or <c>null</c> if the data cannot be parsed.</returns>
        public static decimal? ParseNullableDecimal(IDataRecord o, string key)
        {
            try
            {
                return ParseNullableDecimal(o?[key]);
            }
            catch (IndexOutOfRangeException) { }
            return null;
        }

        /// <summary>
        /// Parses a decimal value from an object that implements the <c>IDictionary&lt;string, object&gt;</c> interface.
        /// </summary>
        /// <param name="o">The IDictionary object containing the key to parse.</param>
        /// <param name="key">The key of the data to parse.</param>
        /// <returns>Returns the value, or <c>null</c> if the data cannot be parsed.</returns>
        public static decimal? ParseNullableDecimal(IDictionary<string, object> o, string key)
        {
            try
            {
                return ParseNullableDecimal(o?[key]);
            }
            catch (IndexOutOfRangeException) { }
            return null;
        }
        */
    }
}
