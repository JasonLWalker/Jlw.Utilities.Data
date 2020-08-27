using System.Collections.Generic;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jlw.Utilities.Data.Tests
{
    public class NullableSByteDataSourceAttribute : DataSourceAttributeBase, ITestDataSource
    {
        public IEnumerable<object[]> GetData(MethodInfo methodInfo)
        {
             foreach (var tuple in DataSourceValues.NullableSByteData)
             {
                 var value = tuple.Value;
                 var expectedValue = tuple.ExpectedValue;

                 var desc = tuple.Description;
                 yield return new object[] {value, expectedValue, desc};
             }
        }
    }
}