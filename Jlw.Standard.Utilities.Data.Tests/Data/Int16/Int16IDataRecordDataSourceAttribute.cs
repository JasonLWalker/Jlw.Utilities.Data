using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jlw.Standard.Utilities.Data.Tests
{
    public class Int16IDataRecordDataSourceAttribute : DataRecordDataSourceAttributeBase, ITestDataSource
    { public IEnumerable<object[]> GetData(MethodInfo methodInfo)
        {
            foreach (var tuple in DataSourceValues.NullableInt16Data)
            {
                yield return new object[] {tuple.Key, tuple.ExpectedValue ?? (Int16)default, tuple.Description};
            }
        }
    }
}