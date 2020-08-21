using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jlw.Utilities.Data.Tests
{
    public class SingleKvpListDataSourceAttribute : KvpListDataSourceAttributeBase, ITestDataSource
    {
        public IEnumerable<object[]> GetData(MethodInfo methodInfo)
        {
            foreach (var tuple in Jlw.Utilities.Data.Tests.DataSourceValues.NullableSingleData)
            {
                yield return new object[] {tuple.Key, tuple.ExpectedValue ?? (Single)default, tuple.Description};
            }
        }
    }
}