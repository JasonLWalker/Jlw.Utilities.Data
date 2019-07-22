using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Jlw.Standard.Utilities.Data
{
    public partial class DataUtility
    {
        public static string ParseString(object obj, string key = null)
        {
            try
            {
                return (GetObjectValue(obj, key) ?? "").ToString();
            }
            catch
            {
                // ignore
            }
            return "";
        }
    }
}
