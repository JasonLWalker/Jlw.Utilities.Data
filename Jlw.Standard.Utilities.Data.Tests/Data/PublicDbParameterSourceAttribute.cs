using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jlw.Standard.Utilities.Data.Tests
{
    public class PublicDbParameterSourceAttribute : Attribute, ITestDataSource
    {
        private MemberTypes _type;                  // Member type to return
        private MethodAttributes _memAttributes;    // Access type of Member
        private MethodAttributes _getAttr;          // attributes for the get accessor
        private MethodAttributes _setAttr;          // attributes for the set accessor

        public PublicDbParameterSourceAttribute(MemberTypes type, MethodAttributes memberAttributes = MethodAttributes.Public, MethodAttributes getAttr = 0, MethodAttributes setAttr = 0)
        {
            _type = type;
            _memAttributes = memberAttributes;
            _getAttr = getAttr;
            _setAttr = setAttr;
        }

        public IEnumerable<object[]> GetData(MethodInfo methodInfo)
        {
            BindingFlags flags = BindingFlags.Default;
            switch (_type)
            { 
                case MemberTypes.Property:  // Retrieve properties (members with get and/or set accessors)
                    if ((_memAttributes & MethodAttributes.Public) == MethodAttributes.Public)  // retrieve public properties
                    {
                        flags = BindingFlags.Instance | BindingFlags.Public;
                        if (_setAttr > 0)   // retrieve properties with set accessors
                        {
                            if ((_setAttr & MethodAttributes.MemberAccessMask) == MethodAttributes.Public) // retrieve public set accessors
                            {
                                yield return new object[] {"DbType", typeof(DbType), flags};
                                yield return new object[] {"Direction", typeof(ParameterDirection), flags};
                                yield return new object[] {"ParameterName", typeof(string), flags};
                                yield return new object[] {"SourceColumn", typeof(string), flags};
                                yield return new object[] {"SourceVersion", typeof(DataRowVersion), flags};
                                yield return new object[] {"Value", typeof(object), flags};
                                yield return new object[] {"Precision", typeof(byte), flags};
                                yield return new object[] {"Scale", typeof(byte), flags};
                                yield return new object[] {"Size", typeof(int), flags};
                            }
                            if ((_setAttr & MethodAttributes.MemberAccessMask) == MethodAttributes.Family) // retrieve internal set accessors
                            {
                                yield return new object[] {"IsNullable", typeof(bool), flags};
                            }
                        }
                        else // do not use set accessor to determine retrieval
                        {
                            yield return new object[] {"DbType", typeof(DbType), flags};
                            yield return new object[] {"Direction", typeof(ParameterDirection), flags};
                            yield return new object[] {"IsNullable", typeof(bool), flags};
                            yield return new object[] {"ParameterName", typeof(string), flags};
                            yield return new object[] {"SourceColumn", typeof(string), flags};
                            yield return new object[] {"SourceVersion", typeof(DataRowVersion), flags};
                            yield return new object[] {"Value", typeof(object), flags};
                            yield return new object[] {"Precision", typeof(byte), flags};
                            yield return new object[] {"Scale", typeof(byte), flags};
                            yield return new object[] {"Size", typeof(int), flags};
                        }

                    }
                    break;
                //case MemberTypes.
            }

        }

        public virtual string GetDisplayName(MethodInfo methodInfo, object[] data)
        {
            return string.Format(CultureInfo.CurrentCulture, "{0} : {1} [{2}]", data[0] ?? "null", data[1] ?? "null", data[2] ?? "null");
        }
    }
}