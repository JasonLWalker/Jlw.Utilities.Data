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
    public class MockDbParameterFixture : BaseModelFixture<MockDbParameter>
    {
        [TestMethod]
        public void Should_Implement_IDbDataParameter()
        {
            var sut = new NullDbParameter();
            Type expectedType = typeof(IDbDataParameter);
            Assert.IsInstanceOfType(sut, expectedType, $"<{sut.GetType().Name}> does not implement <{expectedType.Name}> interface.");
        }

        [TestMethod]
        [PublicDbParameterSource(MemberTypes.Property)]
        public void Should_Exist_ForProperties(string sMemberName, Type type, BindingFlags flags)
        {
            AssertPropertyExists(sMemberName);
        }

        [TestMethod]
        [PublicDbParameterSource(MemberTypes.Property)]
        public void Should_BeAssignableFromType_ForProperties(string sMemberName, Type type, BindingFlags flags)
        {
            var sut = new MockDbParameter();
 
            AssertTypeAssignmentForObjectProperty(sut, sMemberName, type, flags);
        }

        [TestMethod]
        [PublicDbParameterSource(MemberTypes.Property)]
        public void Should_MatchType_ForProperties(string sMemberName, Type type, BindingFlags flags)
        {
            var sut = new MockDbParameter();

            var p = GetPropertyInfoByName(sMemberName, flags);
            Assert.AreSame(type, p.PropertyType, $"'{sMemberName}' <{type}> does not match <{p.PropertyType}>");
        }

        [TestMethod]
        [PublicDbParameterSource(MemberTypes.Property)]
        public void Should_BeReadable_ForProperties(string sMemberName, Type type, BindingFlags flags)
        {
            var p = AssertPropertyIsReadable(sMemberName);
        }

        [TestMethod]
        [PublicDbParameterSource(MemberTypes.Property, MethodAttributes.Public, setAttr:MethodAttributes.Public)]
        public void Should_BePubliclyWritable_ForProperties(string sMemberName, Type type, BindingFlags flags)
        {
            var p = AssertPropertyIsWritable(sMemberName);
            var m = p.SetMethod;
            Assert.IsNotNull(m, "set accessor should not be null.");
            /*
            Console.WriteLine($"{p.MemberType}");
            Console.WriteLine($"{p.SetMethod}");
            Console.WriteLine($"{p.SetMethod.Attributes}");
            */
            Assert.IsTrue(m.IsPublic, "set accessor should be public.");
        }

        [TestMethod]
        [PublicDbParameterSource(MemberTypes.Property, MethodAttributes.Public, setAttr:MethodAttributes.Family)]
        public void Should_BeInternallyWritable_ForProperties(string sMemberName, Type type, BindingFlags flags)
        {
            var p = AssertPropertyIsWritable(sMemberName);
            var m = p.SetMethod;
            Assert.IsNotNull(m, "set accessor should not be null.");
            /*
            Console.WriteLine($"{p.MemberType}");
            Console.WriteLine($"{p.SetMethod}");
            Console.WriteLine($"{p.SetMethod.Attributes}");
            */
            Assert.IsTrue(m.IsFamily, "set accessor should be protected internal.");
        }


    }
}
