using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jlw.Standard.Utilities.Data.Tests
{
    public class SingleDictionaryDataSourceAttribute : DictionaryDataSourceAttributeBase, ITestDataSource
    {
        public IEnumerable<object[]> GetData(MethodInfo methodInfo)
        {
            foreach (var tuple in Jlw.Standard.Utilities.Data.Tests.DataSourceValues.NullableSingleData)
            {
                yield return new object[] {tuple.Key, tuple.ExpectedValue ?? (Single)default, tuple.Description};
            }
        }
    }
}