using System.Collections.Generic;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jlw.Standard.Utilities.Data.Tests
{
    public class NullableSByteIDataRecordDataSourceAttribute : DataRecordDataSourceAttributeBase, ITestDataSource
    { public IEnumerable<object[]> GetData(MethodInfo methodInfo)
        {
            foreach (var tuple in DataSourceValues.NullableSByteData)
            {
                yield return new object[] {tuple.Key, tuple.ExpectedValue, tuple.Description};
            }
        }
    }
}