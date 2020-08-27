using System;
using System.Globalization;
using System.Reflection;

namespace Jlw.Utilities.Data.Tests
{
    public class DictionaryDataSourceAttributeBase : Attribute
    {
        public string GetDisplayName(MethodInfo methodInfo, object[] data)
        {
            if (data != null)
                return string.Format(CultureInfo.CurrentCulture, "dict[\"{0}\"] should be {1}{2}", data[0], (data[1] != null ? "(" + data[1]?.GetType().Name + ")" : ""), data[1] ?? "null");

            return null;
        }


    }
}
