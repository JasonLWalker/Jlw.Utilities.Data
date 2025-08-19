[`< Back`](./)

---

# DataUtility

Namespace: Jlw.Utilities.Data

```csharp
public class DataUtility
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [DataUtility](./jlw.utilities.data.datautility.md)

## Constructors

### **DataUtility()**

```csharp
public DataUtility()
```

## Methods

### **Parse&lt;T&gt;(Object, String)**

```csharp
public static T Parse<T>(object obj, string key)
```

#### Type Parameters

`T`<br>

#### Parameters

`obj` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

`key` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

T<br>

### **ParseAs(Type, Object)**

```csharp
public static object ParseAs(Type type, object data)
```

#### Parameters

`type` [Type](https://docs.microsoft.com/en-us/dotnet/api/system.type)<br>

`data` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

#### Returns

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

### **ParsePrimitiveAs(Type, Object)**

```csharp
public static object ParsePrimitiveAs(Type type, object data)
```

#### Parameters

`type` [Type](https://docs.microsoft.com/en-us/dotnet/api/system.type)<br>

`data` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

#### Returns

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

### **GetCaller(String)**

```csharp
public static string GetCaller(string caller)
```

#### Parameters

`caller` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **IsNumeric(Object)**

```csharp
public static bool IsNumeric(object obj)
```

#### Parameters

`obj` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **GenerateRandom(Type, Nullable&lt;Int32&gt;, Nullable&lt;Int32&gt;, String)**

```csharp
public static object GenerateRandom(Type t, Nullable<int> minLength, Nullable<int> maxLength, string validChars)
```

#### Parameters

`t` [Type](https://docs.microsoft.com/en-us/dotnet/api/system.type)<br>

`minLength` [Nullable&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>

`maxLength` [Nullable&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>

`validChars` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

### **GenerateRandom&lt;T&gt;(Nullable&lt;Int32&gt;, Nullable&lt;Int32&gt;, String)**

```csharp
public static T GenerateRandom<T>(Nullable<int> minLength, Nullable<int> maxLength, string validChars)
```

#### Type Parameters

`T`<br>

#### Parameters

`minLength` [Nullable&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>

`maxLength` [Nullable&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>

`validChars` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

T<br>

### **GenerateRandom&lt;T&gt;(Object, Object, String, Random)**

```csharp
public static T GenerateRandom<T>(object minLength, object maxLength, string validChars, Random rand)
```

#### Type Parameters

`T`<br>

#### Parameters

`minLength` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

`maxLength` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

`validChars` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`rand` [Random](https://docs.microsoft.com/en-us/dotnet/api/system.random)<br>

#### Returns

T<br>

### **GenerateRandom(Type, Object, Object, String, Random)**

```csharp
public static object GenerateRandom(Type t, object minLength, object maxLength, string validChars, Random rand)
```

#### Parameters

`t` [Type](https://docs.microsoft.com/en-us/dotnet/api/system.type)<br>

`minLength` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

`maxLength` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

`validChars` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`rand` [Random](https://docs.microsoft.com/en-us/dotnet/api/system.random)<br>

#### Returns

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

### **ParseBool(Object, String)**

Parses a boolean value from an Dictionary of any type. This method should also catch JObjects with JSON data.
 For string input, the method is case insensitive.
 The method returns `true` for 1, t, true, y, yes. All other values return `false`.

```csharp
public static bool ParseBool(object o, string key)
```

#### Parameters

`o` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
The object containing the data to parse.

`key` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The key to parse.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
Returns the value, or `false` if the data cannot be parsed.

### **ParseNullableBool(Object, String)**

Parses a nullable boolean value from an input object of any type.
 For string input, the method is case insensitive.
 The method returns `true` for 1, t, true, y, yes.
 `Null` or `DBNull` values return null. All other values return `false`.

```csharp
public static Nullable<bool> ParseNullableBool(object obj, string key)
```

#### Parameters

`obj` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
The object containing the data to parse.

`key` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The key to parse.

#### Returns

[Nullable&lt;Boolean&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
Returns the parsed value, or `Null` if the data cannot be parsed.

### **ParseByte(Object, String)**

Converts generic data to byte

```csharp
public static byte ParseByte(object data, string key)
```

#### Parameters

`data` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
The object to convert

`key` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The key or index value to use when extracting the byte value from the object

#### Returns

[Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte)<br>
The byte value contained in the specified object, or default value if unable to parse the value

### **ParseNullableByte(Object, String)**

Converts generic data to byte? (nullable byte)

```csharp
public static Nullable<byte> ParseNullableByte(object obj, string key)
```

#### Parameters

`obj` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
The object to convert

`key` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The key or index value to use when extracting the byte value from the object

#### Returns

[Nullable&lt;Byte&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The byte value contained in the specified object, or null if unable to parse the value

### **ParseCsv(String, Boolean, Boolean)**

```csharp
public static ICollection ParseCsv(string sText, bool useHeader, bool keepEmptyRows)
```

#### Parameters

`sText` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`useHeader` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

`keepEmptyRows` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

#### Returns

[ICollection](https://docs.microsoft.com/en-us/dotnet/api/system.collections.icollection)<br>

### **ParseToCsv(Object, IEnumerable&lt;CsvParserOption&gt;)**

```csharp
public static string ParseToCsv(object o, IEnumerable<CsvParserOption> opts)
```

#### Parameters

`o` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

`opts` [IEnumerable&lt;CsvParserOption&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **ParseToCsv(Object)**

```csharp
public static string ParseToCsv(object o)
```

#### Parameters

`o` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **ParseNullableDateTime(Object, String)**

Parses a `nullable` DateTime object from an input object of any type.
 Returns a DateTime object parsed from the input data, or Null is the input data is null, empty, DBNull, or cannot be parsed.

```csharp
public static Nullable<DateTime> ParseNullableDateTime(object obj, string key)
```

#### Parameters

`obj` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
The object containing the data to parse.

`key` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The key to parse.

#### Returns

[Nullable&lt;DateTime&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
Returns a DateTime object, or Null is the data cannot be parsed.

### **ParseDateTime(Object, String)**

```csharp
public static DateTime ParseDateTime(object obj, string key)
```

#### Parameters

`obj` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

`key` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime)<br>

### **ParseNullableDateTimeOffset(Object, String)**

Parses a `nullable` DateTime object from an input object of any type.
 Returns a DateTimeOffset object parsed from the input data, or Null is the input data is null, empty, DBNull, or cannot be parsed.

```csharp
public static Nullable<DateTimeOffset> ParseNullableDateTimeOffset(object obj, string key)
```

#### Parameters

`obj` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
The object containing the data to parse.

`key` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The key to parse.

#### Returns

[Nullable&lt;DateTimeOffset&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
Returns a DateTimeOffset object, or Null is the data cannot be parsed.

### **ParseDateTimeOffset(Object, String)**

```csharp
public static DateTimeOffset ParseDateTimeOffset(object data, string key)
```

#### Parameters

`data` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

`key` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[DateTimeOffset](https://docs.microsoft.com/en-us/dotnet/api/system.datetimeoffset)<br>

### **ParseDecimal(Object, String)**

Parses a decimal value from an input object of any type.

```csharp
public static decimal ParseDecimal(object obj, string key)
```

#### Parameters

`obj` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
The object containing the data to parse.

`key` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The key to parse.

#### Returns

[Decimal](https://docs.microsoft.com/en-us/dotnet/api/system.decimal)<br>
Returns the value, or `0.0M` if the data cannot be parsed.

### **ParseNullableDecimal(Object, String)**

Parses a decimal value from an input object of any type.

```csharp
public static Nullable<decimal> ParseNullableDecimal(object obj, string key)
```

#### Parameters

`obj` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
The object containing the data to parse.

`key` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The key to parse.

#### Returns

[Nullable&lt;Decimal&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
Returns the value, or `null` if the data cannot be parsed.

### **ParseDouble(Object, String)**

Parses a double value from an input object of any type.

```csharp
public static double ParseDouble(object obj, string key)
```

#### Parameters

`obj` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
The object containing the data to parse.

`key` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The key of the data to parse.

#### Returns

[Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
Returns the value, or `0.0D` if the data cannot be parsed.

### **ParseNullableDouble(Object, String)**

Parses a double value from an input object of any type.

```csharp
public static Nullable<double> ParseNullableDouble(object obj, string key)
```

#### Parameters

`obj` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
The object containing the data to parse.

`key` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The key of the data to parse.

#### Returns

[Nullable&lt;Double&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
Returns the value, or `null` if the data cannot be parsed.

### **Sha256Hash(String)**

```csharp
public static string Sha256Hash(string text)
```

#### Parameters

`text` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Md5Hash(String)**

```csharp
public static string Md5Hash(string text)
```

#### Parameters

`text` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **BaseEncode(Int64, UInt16, String)**

```csharp
public static string BaseEncode(long val, ushort baseN, string chars)
```

#### Parameters

`val` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>

`baseN` [UInt16](https://docs.microsoft.com/en-us/dotnet/api/system.uint16)<br>

`chars` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **BaseDecode(String, Int32, String)**

```csharp
public static long BaseDecode(string s, int baseN, string chars)
```

#### Parameters

`s` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`baseN` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

`chars` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>

### **Base48Encode(Int64)**

```csharp
public static string Base48Encode(long val)
```

#### Parameters

`val` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Base48Decode(String)**

```csharp
public static long Base48Decode(string val)
```

#### Parameters

`val` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>

### **Base25Encode(Int64)**

```csharp
public static string Base25Encode(long val)
```

#### Parameters

`val` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Base25Decode(String)**

```csharp
public static long Base25Decode(string val)
```

#### Parameters

`val` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>

### **GenerateSalt()**

```csharp
public static string GenerateSalt()
```

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **ParseShort(Object, String)**

```csharp
public static short ParseShort(object o, string key)
```

#### Parameters

`o` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

`key` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Int16](https://docs.microsoft.com/en-us/dotnet/api/system.int16)<br>

### **ParseNullableShort(Object, String)**

```csharp
public static Nullable<short> ParseNullableShort(object o, string key)
```

#### Parameters

`o` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

`key` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Nullable&lt;Int16&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>

### **ParseInt16(Object, String)**

Parses a 16-bit integer value from an input object of any type.

```csharp
public static short ParseInt16(object obj, string key)
```

#### Parameters

`obj` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
The object containing the data to parse.

`key` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The key to parse.

#### Returns

[Int16](https://docs.microsoft.com/en-us/dotnet/api/system.int16)<br>
Returns the value, or `0` if the data cannot be parsed.

### **ParseNullableInt16(Object, String)**

Parses a 16-bit integer value from an input object of any type.

```csharp
public static Nullable<short> ParseNullableInt16(object obj, string key)
```

#### Parameters

`obj` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
The object containing the data to parse.

`key` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The key to parse.

#### Returns

[Nullable&lt;Int16&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
Returns an int containing the value, or `null` if the data cannot be parsed.

### **ParseInt32(Object, String)**

```csharp
public static int ParseInt32(object o, string key)
```

#### Parameters

`o` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

`key` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

### **ParseNullableInt32(Object, String)**

```csharp
public static Nullable<int> ParseNullableInt32(object o, string key)
```

#### Parameters

`o` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

`key` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Nullable&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>

### **ParseInt(Object, String)**

Parses a 32-bit integer value from an input object of any type.

```csharp
public static int ParseInt(object obj, string key)
```

#### Parameters

`obj` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
The object containing the data to parse.

`key` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The key to parse.

#### Returns

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
Returns the value, or `0` if the data cannot be parsed.

### **ParseNullableInt(Object, String)**

Parses a 32-bit integer value from an input object of any type.

```csharp
public static Nullable<int> ParseNullableInt(object obj, string key)
```

#### Parameters

`obj` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
The object containing the data to parse.

`key` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The key to parse.

#### Returns

[Nullable&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
Returns an int containing the value, or `null` if the data cannot be parsed.

### **ParseInt64(Object, String)**

```csharp
public static long ParseInt64(object o, string key)
```

#### Parameters

`o` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

`key` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>

### **ParseNullableInt64(Object, String)**

```csharp
public static Nullable<long> ParseNullableInt64(object o, string key)
```

#### Parameters

`o` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

`key` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Nullable&lt;Int64&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>

### **ParseLong(Object, String)**

Parses a 64-bit integer value from an input object of any type.

```csharp
public static long ParseLong(object obj, string key)
```

#### Parameters

`obj` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
The object containing the data to parse.

`key` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The key to parse.

#### Returns

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>
Returns the value, or `0` if the data cannot be parsed.

### **ParseNullableLong(Object, String)**

Parses a 64-bit integer value from an input object of any type.

```csharp
public static Nullable<long> ParseNullableLong(object obj, string key)
```

#### Parameters

`obj` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
The object containing the data to parse.

`key` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The key to parse.

#### Returns

[Nullable&lt;Int64&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
Returns an int containing the value, or `null` if the data cannot be parsed.

### **IpToUInt32(String)**

```csharp
public static uint IpToUInt32(string ip)
```

#### Parameters

`ip` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[UInt32](https://docs.microsoft.com/en-us/dotnet/api/system.uint32)<br>

### **UInt32ToIp(UInt32)**

```csharp
public static string UInt32ToIp(uint ip)
```

#### Parameters

`ip` [UInt32](https://docs.microsoft.com/en-us/dotnet/api/system.uint32)<br>

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **ParseCidrMask(Int32)**

```csharp
public static uint ParseCidrMask(int mask)
```

#### Parameters

`mask` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

#### Returns

[UInt32](https://docs.microsoft.com/en-us/dotnet/api/system.uint32)<br>

### **ParseCidrMask(String)**

```csharp
public static uint ParseCidrMask(string ip)
```

#### Parameters

`ip` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[UInt32](https://docs.microsoft.com/en-us/dotnet/api/system.uint32)<br>

### **GetObjectValue(Object, String)**

```csharp
public static object GetObjectValue(object obj, string key)
```

#### Parameters

`obj` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

`key` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

### **GetReflectedMemberValueByName(Object, String, BindingFlags)**

```csharp
public static object GetReflectedMemberValueByName(object instance, string memberName, BindingFlags flags)
```

#### Parameters

`instance` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

`memberName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`flags` [BindingFlags](https://docs.microsoft.com/en-us/dotnet/api/system.reflection.bindingflags)<br>

#### Returns

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

### **SetReflectedMemberValueByName(Object, String, Object, BindingFlags)**

```csharp
public static object SetReflectedMemberValueByName(object instance, string memberName, object value, BindingFlags flags)
```

#### Parameters

`instance` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

`memberName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`value` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

`flags` [BindingFlags](https://docs.microsoft.com/en-us/dotnet/api/system.reflection.bindingflags)<br>

#### Returns

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

### **SetReflectedPropertyValueByName(Object, String, Object, BindingFlags)**

```csharp
public static object SetReflectedPropertyValueByName(object instance, string memberName, object value, BindingFlags flags)
```

#### Parameters

`instance` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

`memberName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`value` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

`flags` [BindingFlags](https://docs.microsoft.com/en-us/dotnet/api/system.reflection.bindingflags)<br>

#### Returns

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

### **SetReflectedFieldValueByName(Object, String, Object, BindingFlags)**

```csharp
public static object SetReflectedFieldValueByName(object instance, string memberName, object value, BindingFlags flags)
```

#### Parameters

`instance` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

`memberName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`value` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

`flags` [BindingFlags](https://docs.microsoft.com/en-us/dotnet/api/system.reflection.bindingflags)<br>

#### Returns

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

### **GetReflectedPropertyValueByName(Object, String, BindingFlags)**

```csharp
public static object GetReflectedPropertyValueByName(object instance, string memberName, BindingFlags flags)
```

#### Parameters

`instance` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

`memberName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`flags` [BindingFlags](https://docs.microsoft.com/en-us/dotnet/api/system.reflection.bindingflags)<br>

#### Returns

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

### **GetReflectedFieldValueByName(Object, String, BindingFlags)**

```csharp
public static object GetReflectedFieldValueByName(object instance, string memberName, BindingFlags flags)
```

#### Parameters

`instance` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

`memberName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`flags` [BindingFlags](https://docs.microsoft.com/en-us/dotnet/api/system.reflection.bindingflags)<br>

#### Returns

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

### **GetTypeArgs(Type[])**

```csharp
public static string GetTypeArgs(Type[] typeArray)
```

#### Parameters

`typeArray` [Type[]](https://docs.microsoft.com/en-us/dotnet/api/system.type)<br>

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **GetTypeName(Type)**

```csharp
public static string GetTypeName(Type t)
```

#### Parameters

`t` [Type](https://docs.microsoft.com/en-us/dotnet/api/system.type)<br>

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **GetGenericTypeString(Type)**

```csharp
public static string GetGenericTypeString(Type t)
```

#### Parameters

`t` [Type](https://docs.microsoft.com/en-us/dotnet/api/system.type)<br>

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **GetReflectedObjectInstanceFromAssembly(Assembly, String)**

```csharp
public static object GetReflectedObjectInstanceFromAssembly(Assembly assembly, string objName)
```

#### Parameters

`assembly` [Assembly](https://docs.microsoft.com/en-us/dotnet/api/system.reflection.assembly)<br>

`objName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

### **GetReflectedMethodInfoFromAssembly(Object, String, IEnumerable&lt;Type&gt;)**

```csharp
public static MethodInfo GetReflectedMethodInfoFromAssembly(object instance, string methodName, IEnumerable<Type> argTypeList)
```

#### Parameters

`instance` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

`methodName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`argTypeList` [IEnumerable&lt;Type&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>

#### Returns

[MethodInfo](https://docs.microsoft.com/en-us/dotnet/api/system.reflection.methodinfo)<br>

### **InvokeReflectedMethodFromAssembly(Assembly, String, String, IEnumerable&lt;Object&gt;)**

```csharp
public static object InvokeReflectedMethodFromAssembly(Assembly assembly, string objName, string methodName, IEnumerable<object> argList)
```

#### Parameters

`assembly` [Assembly](https://docs.microsoft.com/en-us/dotnet/api/system.reflection.assembly)<br>

`objName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`methodName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`argList` [IEnumerable&lt;Object&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>

#### Returns

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

### **InvokeReflectedMethodFromInstance(Object, String, IEnumerable&lt;Object&gt;)**

```csharp
public static object InvokeReflectedMethodFromInstance(object instance, string methodName, IEnumerable<object> argList)
```

#### Parameters

`instance` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

`methodName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`argList` [IEnumerable&lt;Object&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>

#### Returns

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

### **InvokeReflectedMethodFromInstance(Object, MethodInfo, IEnumerable&lt;Object&gt;)**

```csharp
public static object InvokeReflectedMethodFromInstance(object instance, MethodInfo method, IEnumerable<object> argList)
```

#### Parameters

`instance` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

`method` [MethodInfo](https://docs.microsoft.com/en-us/dotnet/api/system.reflection.methodinfo)<br>

`argList` [IEnumerable&lt;Object&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>

#### Returns

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

### **ParseSByte(Object, String)**

Extracts a sbyte value from the specified object

```csharp
public static sbyte ParseSByte(object obj, string key)
```

#### Parameters

`obj` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
The object from which to extract the sbyte value

`key` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The key or index value to use when extracting the sbyte value from the object

#### Returns

[SByte](https://docs.microsoft.com/en-us/dotnet/api/system.sbyte)<br>
The sbyte value contained in the specified object, or default value if unable to parse the value

### **ParseNullableSByte(Object, String)**

Extracts a nullable sbyte value from the specified object

```csharp
public static Nullable<sbyte> ParseNullableSByte(object obj, string key)
```

#### Parameters

`obj` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
The object from which to extract the sbyte value

`key` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The key or index value to use when extracting the sbyte value from the object

#### Returns

[Nullable&lt;SByte&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The sbyte value contained in the specified object, or null if unable to parse the value

### **ParseFloat(Object, String)**

```csharp
public static float ParseFloat(object data, string key)
```

#### Parameters

`data` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

`key` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Single](https://docs.microsoft.com/en-us/dotnet/api/system.single)<br>

### **ParseNullableFloat(Object, String)**

```csharp
public static Nullable<float> ParseNullableFloat(object data, string key)
```

#### Parameters

`data` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

`key` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Nullable&lt;Single&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>

### **ParseSingle(Object, String)**

Parses a float value from an object that implements the `IDataRecord` interface.
 This includes SqlDataReader and other inherited SQL Data records.

```csharp
public static float ParseSingle(object o, string key)
```

#### Parameters

`o` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
The IDataRecord object containing the key to parse.

`key` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The key of the data to parse.

#### Returns

[Single](https://docs.microsoft.com/en-us/dotnet/api/system.single)<br>
Returns the value, or `0.0f` if the data cannot be parsed.

### **ParseNullableSingle(Object, String)**

Parses a float value from an input object of any type.

```csharp
public static Nullable<float> ParseNullableSingle(object obj, string key)
```

#### Parameters

`obj` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
The object containing the data to parse.

`key` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The key of the data to parse.

#### Returns

[Nullable&lt;Single&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
Returns the value, or `null` if the data cannot be parsed.

### **ParseString(Object, String, Int32)**

```csharp
public static string ParseString(object obj, string key, int length)
```

#### Parameters

`obj` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

`key` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`length` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **ParseString(Object, Int32)**

```csharp
public static string ParseString(object obj, int length)
```

#### Parameters

`obj` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

`length` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **ParseString(Object, String)**

```csharp
public static string ParseString(object obj, string key)
```

#### Parameters

`obj` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

`key` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **ParseNullableString(Object, String)**

```csharp
public static string ParseNullableString(object obj, string key)
```

#### Parameters

`obj` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

`key` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **ParseNullableString(Object, String, Int32)**

```csharp
public static string ParseNullableString(object obj, string key, int length)
```

#### Parameters

`obj` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

`key` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`length` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **ParseNullableString(Object, Int32)**

```csharp
public static string ParseNullableString(object obj, int length)
```

#### Parameters

`obj` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

`length` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **GetNumberSuffix(Object)**

Extracts the number suffix as a string from an input object of any type.
 Returns a grammatically correct number suffix for the parsed number as a string.

```csharp
public static string GetNumberSuffix(object n)
```

#### Parameters

`n` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
The object to parse

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Returns the number suffix parsed value, or an empty string if the `n` parameter is `null`.

### **UcWords(String)**

Sets the first character of every word in the string to uppercase.

```csharp
public static string UcWords(string s)
```

#### Parameters

`s` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The string to operate on.

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Returns a copy of the input string with the 1st character of all of the words uppercase.

### **FormatPhone(String, String)**

```csharp
public static string FormatPhone(string s, string format)
```

#### Parameters

`s` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`format` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Left(String, Int32)**

```csharp
public static string Left(string s, int length)
```

#### Parameters

`s` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`length` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **ExtractDate(Nullable&lt;DateTime&gt;, String)**

Extracts the date as a string from a nullable `DateTime` object.
 Returns the date as a string in the MM/dd/yyyy format by default, but also supports custom dates via the format argument.

```csharp
public static string ExtractDate(Nullable<DateTime> dt, string format)
```

#### Parameters

`dt` [Nullable&lt;DateTime&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The nullable DateTime object to parse

`format` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The format to parse the date into. Defaults to "MM/dd/yyyy".

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Returns the formatted date string, or an empty string if the `dt` parameter is `null`.

### **ExtractTime(Nullable&lt;DateTime&gt;, String)**

Extracts the time as a string from a `nullable` DateTime object.
 Returns the time as a string in the h:mm tt format by default, but also supports custom dates via the format argument.

```csharp
public static string ExtractTime(Nullable<DateTime> dt, string format)
```

#### Parameters

`dt` [Nullable&lt;DateTime&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The nullable DateTime object to parse

`format` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The format to parse the date into.

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Returns the formatted time string, or an empty string if the `dt` parameter is Null.

### **ExtractDateSuffix(Nullable&lt;DateTime&gt;)**

Extracts the date suffix as a string from a `nullable` DateTime object.
 Returns a grammatically correct number suffix for the day value in the `dt` DateTime object as a string.

```csharp
public static string ExtractDateSuffix(Nullable<DateTime> dt)
```

#### Parameters

`dt` [Nullable&lt;DateTime&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The nullable DateTime object to parse

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Returns the number suffix for the day value, or an empty string if the `dt` parameter is Null.

### **ExtractISOWeekNumber(Nullable&lt;DateTime&gt;)**

Extracts the ISO 8601 week number from a `nullable` DateTime object. 
 Returns the ISO 8601 week number that should (hopefully) match the week number returned by the isoWeek function of the Moment.js library.

```csharp
public static int ExtractISOWeekNumber(Nullable<DateTime> date)
```

#### Parameters

`date` [Nullable&lt;DateTime&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The nullable DateTime object to parse

#### Returns

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
Returns the ISO 8601 week number, or an empty string if the `dt` parameter is Null.

### **IsValidEmail(String)**

Determines whether the email address is in a valid email format. Does not check to see if email address actually exists.

```csharp
public static bool IsValidEmail(string email)
```

#### Parameters

`email` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The email.

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
`true` if the email is valid; otherwise, `false`.

---

[`< Back`](./)
