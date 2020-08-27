using System.Collections.Generic;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jlw.Utilities.Data.Tests
{
    public class ByteDataSourceAttribute : DataSourceAttributeBase, ITestDataSource
    {
        public IEnumerable<object[]> GetData(MethodInfo methodInfo)
        {
             foreach (var tuple in DataSourceValues.NullableByteData)
             {
                 var value = tuple.Value;
                 var expectedValue = tuple.ExpectedValue ?? (byte)default;

                 var desc = tuple.Description;
                 yield return new object[] {value, expectedValue, desc};
             }
        }

    }
}