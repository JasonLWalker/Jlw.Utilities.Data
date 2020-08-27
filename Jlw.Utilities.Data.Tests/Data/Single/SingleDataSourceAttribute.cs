﻿using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jlw.Utilities.Data.Tests
{
    public class SingleDataSourceAttribute : DataSourceAttributeBase, ITestDataSource
    {
        public IEnumerable<object[]> GetData(MethodInfo methodInfo)
        {
             foreach (var tuple in Jlw.Utilities.Data.Tests.DataSourceValues.NullableSingleData)
             {
                 var value = tuple.Value;
                 var expectedValue = tuple.ExpectedValue ?? (Single)default;

                 var desc = tuple.Description;
                 yield return new object[] {value, expectedValue, desc};
             }
        }
    }
}