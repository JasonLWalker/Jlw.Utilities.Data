using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jlw.Standard.Utilities.Data.Tests
{
    public class NullableBooleanDataSourceAttribute : DataSourceAttributeBase, ITestDataSource
    {
        public IEnumerable<object[]> GetData(MethodInfo methodInfo)
        {
            foreach (var tuple in DataSourceValues.NullableBoolData.ToList())
            {
                var value = tuple.Value;
                var expectedValue = tuple.ExpectedValue;

                var desc = tuple.Description;
                yield return new object[] {value, expectedValue, desc};
            }
        }
    }
}