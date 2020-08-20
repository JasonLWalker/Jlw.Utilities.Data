using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jlw.Standard.Utilities.Data.Tests.UnitTests.DbUtilityModels
{
    public class ModelParameterSourceAttribute : DataSourceAttributeBase, ITestDataSource
    {
        protected IEnumerable<PropertyInfo> _props;

        public ModelParameterSourceAttribute(Type type)
        {
            _props = type.GetProperties();
        }

        public IEnumerable<object[]> GetData(MethodInfo methodInfo)
        {
            foreach (var p in _props)
            {
                yield return new object[] { p.Name, p.PropertyType};
            }
        }

    }
}