using System.Collections.Generic;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jlw.Standard.Utilities.Data.Tests
{
    public class NullableSingleDataSourceAttribute : DataSourceAttributeBase, ITestDataSource
    {
        public IEnumerable<object[]> GetData(MethodInfo methodInfo)
        {
             foreach (var tuple in Jlw.Standard.Utilities.Data.Tests.DataSourceValues.NullableSingleData)
             {
                 var value = tuple.Value;
                 var expectedValue = tuple.ExpectedValue;

                 var desc = tuple.Description;
                 yield return new object[] {value, expectedValue, desc};
             }
        }
    }
}