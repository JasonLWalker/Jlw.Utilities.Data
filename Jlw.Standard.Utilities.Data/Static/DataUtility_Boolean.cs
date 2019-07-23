using System;

namespace Jlw.Standard.Utilities.Data
{
    public partial class DataUtility
    {
        /// <summary>
        /// Parses a boolean value from an Dictionary of any type. This method should also catch JObjects with JSON data.
        /// For string input, the method is case insensitive.
        /// The method returns <c>true</c> for 1, t, true, y, yes. All other values return <c>false</c>.
        /// </summary>
        /// <param name="o">The object containing the data to parse.</param>
        /// <param name="key">The key to parse.</param>
        /// <returns>Returns the value, or <c>false</c> if the data cannot be parsed.</returns>
        public static bool ParseBool(object o, string key = null) => ParseNullableBool(o, key) ?? default;
        
        /// <summary>
        /// Parses a nullable boolean value from an input object of any type.
        /// For string input, the method is case insensitive.
        /// The method returns <c>true</c> for 1, t, true, y, yes.
        /// <c>Null</c> or <c>DBNull</c> values return null. All other values return <c>false</c>.
        /// </summary>
        /// <param name="obj">The object containing the data to parse.</param>
        /// <param name="key">The key to parse.</param>
        /// <returns>Returns the parsed value, or <c>Null</c> if the data cannot be parsed.</returns>
        public static bool? ParseNullableBool(object obj, string key = null)
        {
            var data = GetObjectValue(obj, key);

            if (IsNullOrWhitespace(data) || data is DateTimeOffset || data is DateTime)
                return null;

            switch (data?.ToString().ToLower().Trim())
            {
                case "1":
                case "t":
                case "true":
                case "y":
                case "yes":
                    return true;
            }

            TypeCode tc = Type.GetTypeCode(data?.GetType());
            switch (tc)
            {
                case TypeCode.Byte:
                    byte b = (byte) (data ?? 0);
                    if (b == '1' || b == 'y' || b == 'Y' || b =='t' || b =='T')
                        return true;

                    return false;
                case TypeCode.Char:
                    char c = (char)(data ?? 0);
                    if (c == '1' || c == 1)
                        return true;
                    
                    return false;
            }

            return false;
        }
    }
}
