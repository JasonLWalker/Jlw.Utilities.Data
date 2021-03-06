﻿using System.Collections.Generic;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jlw.Utilities.Data.Tests
{
    public class Int32DataSourceAttribute : DataSourceAttributeBase, ITestDataSource
    {
        public IEnumerable<object[]> GetData(MethodInfo methodInfo)
        {
             foreach (var tuple in DataSourceValues.NullableInt32Data)
             {
                 var value = tuple.Value;
                 var expectedValue = tuple.ExpectedValue ?? (int)default;

                 var desc = tuple.Description;
                 yield return new object[] {value, expectedValue, desc};
             }
        }
    }
}