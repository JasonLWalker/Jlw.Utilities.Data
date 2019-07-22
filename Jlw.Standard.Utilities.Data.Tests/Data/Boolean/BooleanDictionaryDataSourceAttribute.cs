﻿using System.Collections.Generic;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jlw.Standard.Utilities.Data.Tests
{
    public class BooleanDictionaryDataSourceAttribute : DictionaryDataSourceAttributeBase, ITestDataSource
    {
        public IEnumerable<object[]> GetData(MethodInfo methodInfo)
        {
            foreach (var tuple in DataSourceValues.NullableBoolData)
            {
                yield return new object[] {tuple.Key, tuple.ExpectedValue ?? false, tuple.Description};
            }
        }
    }
}