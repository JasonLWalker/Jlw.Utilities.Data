using System.Collections.Generic;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jlw.Utilities.Data.Tests
{
    public class Int64IDataRecordDataSourceAttribute : DataRecordDataSourceAttributeBase, ITestDataSource
    { public IEnumerable<object[]> GetData(MethodInfo methodInfo)
        {
            foreach (var tuple in DataSourceValues.NullableInt64Data)
            {
                yield return new object[] {tuple.Key, tuple.ExpectedValue ?? (System.Int64)default, tuple.Description};
            }
        }
    }
}