using System;
using Jlw.Utilities.Data;

namespace Jlw.Extensions.DataParsing
{
    /// <summary>
    /// 
    /// </summary>
    public static partial class ObjectParsingExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="key"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T ParseTo<T>(this object obj, string key = null)
        {
            return DataUtility.Parse<T>(obj, key);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string? NullIfWhiteSpace(this object? value, string? key = null)
        {
            string? s;
            if (value is string str)
            {
                s = str;
            }
            else
            {
                s = DataUtility.ParseNullableString(value, key);
            }

            return !string.IsNullOrWhiteSpace(s) ? s : null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="minLength"></param>
        /// <param name="maxLength"></param>
        /// <param name="validChars"></param>
        /// <param name="rand"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GenerateRandom<T>(object minLength, object maxLength = null, string validChars = null, Random rand = null)
        {
            return DataUtility.GenerateRandom<T>(minLength, maxLength, validChars, rand);
        }

    }
}
