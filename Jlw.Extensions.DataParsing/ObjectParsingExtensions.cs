using System;
using Jlw.Utilities.Data;

namespace Jlw.Extensions.DataParsing
{
    public static partial class ObjectParsingExtensions
    {
        public static T ParseTo<T>(this object obj, string key = null)
        {
            return DataUtility.Parse<T>(obj, key);
        }

        public static T GenerateRandom<T>(object minLength, object maxLength = null, string validChars = null, Random rand = null)
        {
            return DataUtility.GenerateRandom<T>(minLength, maxLength, validChars, rand);
        }

    }
}
