using System.Collections.Generic;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jlw.Standard.Utilities.Data.Tests
{
    public class BooleanDataSourceAttribute : DataSourceAttributeBase, ITestDataSource
    {
        public IEnumerable<object[]> GetData(MethodInfo methodInfo)
        {
             foreach (var tuple in DataSourceValues.NullableBoolData)
             {
                 var value = tuple.Value;
                 var expectedValue = tuple.ExpectedValue ?? false;

                 var desc = tuple.Description;
                 yield return new object[] {value, expectedValue, desc};
             }
        }

    }
}