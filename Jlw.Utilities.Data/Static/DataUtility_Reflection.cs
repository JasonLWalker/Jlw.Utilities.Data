﻿
// ReSharper disable once CheckNamespace

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Newtonsoft.Json.Linq;

namespace Jlw.Utilities.Data
{
    public partial class DataUtility
    {
        /// <inheritdoc />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object GetObjectValue(object obj, string key = null)
        {
            if (obj is null) return null;
            object o = obj;
            try
            {
                if (!string.IsNullOrWhiteSpace(key))
                {
                    switch (obj)
                    {
                        case IEnumerable<KeyValuePair<string, object>> enumerable:
                            return enumerable.FirstOrDefault(kvp => kvp.Key == key).Value;
                        case JArray ja:
                            return GetObjectValue(ja.FirstOrDefault(x=>x.Path == key));
                        case JObject jo:
                            return GetObjectValue(jo[key]);
                        case JToken jt:
                            return GetObjectValue(jt.FirstOrDefault(x => x.Path == key));
                        case IDictionary dict:
                            return dict.Contains(key) ? dict[key] : null;
                        case IDataRecord record:
                            return (Enumerable.Range(0, record.FieldCount).Any(x => record.GetName(x) == key)) ? record[key] : DBNull.Value;
                    }

                    var t = obj?.GetType();

                    var fieldInfo = t?.GetFields().FirstOrDefault(x => x.Name == key);
                    if (fieldInfo != null)
                        return fieldInfo.GetValue(obj);

                    var propInfo = t?.GetProperties().FirstOrDefault(x => x.Name == key && x.CanRead);
                    if (propInfo != null)
                        return propInfo.GetValue(obj);

                    // Unable to match a field, or property to a key assume that key is not found and return null
                    return null;
                }

                switch (obj)
                {
                    case Enum:
                        Type enumType = Enum.GetUnderlyingType(obj.GetType());
                        return Convert.ChangeType(obj, enumType);
                    case JObject:
                    case JValue:
                        var jv = (JToken)obj;
                        switch (jv.Type)
                        {
                            case JTokenType.Boolean:
                                return jv.ToObject<bool>();
                            case JTokenType.Date:
                                return jv.ToObject<DateTime>();
                            case JTokenType.TimeSpan:
                                return jv.ToObject<TimeSpan>();
                            case JTokenType.Float:
                                return jv.ToObject<double>();
                            case JTokenType.Integer:
                                return jv.ToObject<long>();
                            case JTokenType.Null:
                                return null;
                            case JTokenType.Uri:
                            case JTokenType.String:
                            case JTokenType.Guid:
                                return jv.ToObject<string>();
                        }
                        break;
                }

                /*
                if (obj is Enum)
                {
                    Type enumType = Enum.GetUnderlyingType(obj.GetType());
                    return Convert.ChangeType(obj, enumType);
                }
                */


            }
            catch
            {
                // Ignore
                o = null;
            }

            return o;
        }

        public static object GetReflectedMemberValueByName(object instance, string memberName, BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static)
        {
            var t = instance?.GetType();
            var memberInfo = t?.GetMember(memberName, flags).FirstOrDefault(o => o.MemberType == MemberTypes.Field || o.MemberType == MemberTypes.Property);
            if (memberInfo is null)
                return default;

            if (memberInfo.MemberType is MemberTypes.Field)
            {
                var o = t.GetField(memberName, flags);
                return o?.GetValue(instance);
            }

            if (memberInfo.MemberType is MemberTypes.Property)
            {
                var o = t.GetProperty(memberName, flags);
                if (o?.GetMethod == null)
                    return default;

                return o?.GetValue(instance);
            }

            return default;
        }

        public static object SetReflectedMemberValueByName(object instance, string memberName, object value, BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static)
        {
            var t = instance?.GetType();
            var memberInfo = t?.GetMember(memberName, flags).FirstOrDefault(o => o.MemberType == MemberTypes.Field || o.MemberType == MemberTypes.Property);
            if (memberInfo is null)
                return default;

            if (memberInfo.MemberType is MemberTypes.Field)
            {
                return SetReflectedFieldValueByName(instance, memberName, value, flags);
            }

            if (memberInfo.MemberType is MemberTypes.Property)
            {
                return SetReflectedPropertyValueByName(instance, memberName, value, flags);
            }

            return default;
        }

        public static object SetReflectedPropertyValueByName(object instance, string memberName, object value, BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static)
        {
            var t = instance?.GetType();
            var o = t?.GetProperty(memberName, flags);
            object val = DataUtility.ParseAs(o?.PropertyType ?? typeof(object), value);
            if (o?.SetMethod != null)
            {
                InvokeReflectedMethodFromInstance(instance, o.SetMethod, new Object[] { val });
                val = ParseAs(o.PropertyType, o.GetValue(instance));
            }
            return val;
        }

        public static object SetReflectedFieldValueByName(object instance, string memberName, object value, BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static)
        {
            var t = instance?.GetType();
            var o = t?.GetField(memberName, flags);
            if (o == null) return default;

            object val = DataUtility.ParseAs(o.FieldType , o.GetValue(instance));
            o.SetValue(instance, val);

            return o.GetValue(instance);
        }



        public static object GetReflectedPropertyValueByName(object instance, string memberName, BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static)
        {
            var t = instance?.GetType();
            var o = t.GetProperty(memberName, flags);
            if (o?.GetMethod == null)
                return default;

            return o?.GetValue(instance);
        }

        public static object GetReflectedFieldValueByName(object instance, string memberName, BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static)
        {
            var t = instance?.GetType();
            var o = t?.GetField(memberName, flags);
            return o?.GetValue(instance);
        }

        public static string GetTypeArgs(Type[] typeArray)
        {
            string sArgList = "";
            foreach (Type typ in typeArray)
            {
                string sType = GetTypeName(typ);
                sArgList += $"{sType}, ";
            }


            return sArgList.Trim(',', ' ');
        }

        public static string GetTypeName(Type t)
        {
            var tc = Type.GetTypeCode(t);
            switch (tc)
            {
                case TypeCode.Boolean:
                    return "bool";
                case TypeCode.Byte:
                    return "byte";
                case TypeCode.Char:
                    return "char";
                case TypeCode.Double:
                    return "double";
                case TypeCode.Int16:
                    return "short";
                case TypeCode.Int32:
                    return "int";
                case TypeCode.Int64:
                    return "long";
                case TypeCode.Object:
                    if (t.IsGenericType)
                    {
                        if (t.GetGenericTypeDefinition() == typeof(Nullable<>))
                            return GetTypeName(t.GetGenericArguments()[0]) + "?";
                        else
                        {
                            return GetGenericTypeString(t) + ", ";
                        }
                    }

                    break;
                case TypeCode.Single:
                    return "float";
                case TypeCode.String:
                    return "string";
            }

            return t.Name;
        }

        // from https://stackoverflow.com/questions/2448800/given-a-type-instance-how-to-get-generic-type-name-in-c#2448918
        public static string GetGenericTypeString(Type t)
        {
            if (!t.IsGenericType)
                return GetTypeName(t);
            string genericTypeName = t.GetGenericTypeDefinition().Name;
            genericTypeName = genericTypeName.Substring(0,
                genericTypeName.IndexOf('`'));
            string genericArgs = string.Join(", ",
                t.GetGenericArguments()
                    .Select(ta => GetGenericTypeString(ta)).ToArray());
            return genericTypeName + "<" + genericArgs + ">";
        }

        public static object GetReflectedObjectInstanceFromAssembly(Assembly assembly, string objName)
        {
            if (assembly == null) throw new ArgumentNullException(nameof(assembly));
            Type t = assembly.GetType(objName);

            if (t == null) throw new NullReferenceException($"unable to locate {objName} in assembly");

            object instance = Activator.CreateInstance(t, false);
            if (t == null) throw new NullReferenceException($"unable to create an instance of {objName}");

            return instance;
        }

        public static MethodInfo GetReflectedMethodInfoFromAssembly(object instance, string methodName, IEnumerable<Type> argTypeList)
        {
            if (instance == null) throw new ArgumentNullException(nameof(instance));

            Type t = instance.GetType();

            MethodInfo methodInfo = t.GetMethod(methodName, argTypeList.ToArray());

            if (methodInfo == null) throw new NullReferenceException($"unable to retrieve method {methodName} from {GetGenericTypeString(t)}");

            return methodInfo;
        }
        public static object InvokeReflectedMethodFromAssembly(Assembly assembly, string objName, string methodName, IEnumerable<object> argList)
        {
            object instance = GetReflectedObjectInstanceFromAssembly(assembly, objName);
            if (instance == null) throw new NullReferenceException($"unable to create an instance of {objName}");

            object[] args = argList as object[] ?? argList.ToArray();

            MethodInfo methodInfo = GetReflectedMethodInfoFromAssembly(instance, methodName, args.Select(o => o.GetType()));
            if (methodInfo == null) throw new NullReferenceException($"unable to retrieve method {methodName} from {GetGenericTypeString(instance.GetType())}");

            return methodInfo.Invoke(instance, args);
        }

        public static object InvokeReflectedMethodFromInstance(object instance, string methodName, IEnumerable<object> argList)
        {
            if (instance == null) throw new ArgumentNullException(nameof(instance));

            object[] args = argList as object[] ?? argList?.ToArray() ?? new object[]{};
            MethodInfo methodInfo = GetReflectedMethodInfoFromAssembly(instance, methodName, args.Select(o => o.GetType()));
            if (methodInfo == null) throw new NullReferenceException($"unable to retrieve method {methodName} from {GetGenericTypeString(instance.GetType())}");
            return methodInfo.Invoke(instance, args);
        }


        public static object InvokeReflectedMethodFromInstance(object instance, MethodInfo method, IEnumerable<object> argList)
        {
            if (instance == null) throw new ArgumentNullException(nameof(instance));
            if (method == null) throw new ArgumentNullException(nameof(method));

            object[] args = argList as object[] ?? argList.ToArray();
            return method.Invoke(instance, args);
        }



    }
}
