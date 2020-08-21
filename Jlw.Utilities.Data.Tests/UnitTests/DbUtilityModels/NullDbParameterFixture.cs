using System;
using System.Data;
using System.Reflection;
using System.Text;
using Jlw.Utilities.Data.DbUtility;
using Jlw.Standard.Utilities.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Jlw.Utilities.Data.Tests.UnitTests.DbUtilityModels
{
    [TestClass]
    public class NullDbParameterFixture : BaseModelFixture<NullDbParameter>
    {
        [TestMethod]
        public void ShouldImplementIDbDataParameter()
        {
            var sut = new NullDbParameter();
            Type expectedType = typeof(IDbDataParameter);
            Assert.IsInstanceOfType(sut, expectedType, $"<{sut.GetType().Name}> does not implement <{expectedType.Name}> interface.");
        }


        [TestMethod]
        [PublicDbParameterSource(MemberTypes.Property)]
        public void ShouldExistForProperties(string sMemberName, Type type, BindingFlags flags)
        {
            AssertPropertyExists(sMemberName);
        }

        [TestMethod]
        [PublicDbParameterSource(MemberTypes.Property)]
        public void ShouldBeAssignableFromTypeForProperties(string sMemberName, Type type, BindingFlags flags)
        {
            var sut = new NullDbParameter();
 
            AssertTypeAssignmentForObjectProperty(sut, sMemberName, type, flags);
        }

        [TestMethod]
        [PublicDbParameterSource(MemberTypes.Property)]
        public void ShouldMatchTypeForProperties(string sMemberName, Type type, BindingFlags flags)
        {
            var sut = new NullDbParameter();

            var p = GetPropertyInfoByName(sMemberName, flags);
            Assert.AreSame(type, p.PropertyType, $"'{sMemberName}' <{type}> does not match <{p.PropertyType}>");
        }

        [TestMethod]
        [PublicDbParameterSource(MemberTypes.Property)]
        public void ShouldBeReadableForProperties(string sMemberName, Type type, BindingFlags flags)
        {
            var p = AssertPropertyIsReadable(sMemberName);
        }

        [TestMethod]
        [PublicDbParameterSource(MemberTypes.Property, MethodAttributes.Public, setAttr:MethodAttributes.Public)]
        public void ShouldBePubliclyWritableForProperties(string sMemberName, Type type, BindingFlags flags)
        {
            var p = AssertPropertyIsWritable(sMemberName);
            var m = p.SetMethod;
            Assert.IsNotNull(m, "set accessor should not be null.");
            Assert.IsTrue(m.IsPublic, "set accessor should be public.");
        }

        [TestMethod]
        [PublicDbParameterSource(MemberTypes.Property, MethodAttributes.Public, setAttr:MethodAttributes.Family)]
        public void ShouldBeInternallyWritableForProperties(string sMemberName, Type type, BindingFlags flags)
        {
            var p = AssertPropertyIsWritable(sMemberName);
            var m = p.SetMethod;
            Assert.IsNotNull(m, "set accessor should not be null.");
            Assert.IsTrue(m.IsFamily, "set accessor should be protected internal.");
        }

    }
}
