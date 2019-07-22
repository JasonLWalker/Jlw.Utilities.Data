using System.Collections.Generic;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jlw.Standard.Utilities.Data.Tests
{
    public class DoubleKvpListDataSourceAttribute : KvpListDataSourceAttributeBase, ITestDataSource
    {
        public IEnumerable<object[]> GetData(MethodInfo methodInfo)
        {
            foreach (var tuple in DataSourceValues.NullableDoubleData)
            {
                yield return new object[] {tuple.Key, tuple.ExpectedValue ?? (System.Double)default, tuple.Description};
            }
        }
    }
}