using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Jlw.Utilities.Data
{
    public partial class DataUtility
    {
        public static string ParseString(object obj, string key = null)
        {
            if (obj is null)
                return "";

            try
            {
                Type t = obj.GetType();

                if (t.IsPrimitive || obj is string || obj is IEnumerable)
                {
                    return GetObjectValue(obj, key)?.ToString();
                }

                var s = (GetObjectValue(obj, key) ?? "").ToString();


                return t.ToString() == s ? "" : s;
            }
            catch
            {
                // ignore
            }
            return "";
        }

        public static string ParseNullableString(object obj, string key = null)
        {
            if (obj is null || GetObjectValue(obj, key) is null)
                return null;

            return ParseString(obj, key);
        }

    }
}
