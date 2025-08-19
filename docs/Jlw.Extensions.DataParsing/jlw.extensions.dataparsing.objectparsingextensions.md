[`< Back`](./)

---

# ObjectParsingExtensions

Namespace: Jlw.Extensions.DataParsing



```csharp
public static class ObjectParsingExtensions
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [ObjectParsingExtensions](./jlw.extensions.dataparsing.objectparsingextensions.md)<br>
Attributes [NullableContextAttribute](./system.runtime.compilerservices.nullablecontextattribute.md), [NullableAttribute](./system.runtime.compilerservices.nullableattribute.md), [ExtensionAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.extensionattribute)

## Methods

### **ParseTo&lt;T&gt;(Object, String)**



```csharp
public static T ParseTo<T>(object obj, string key)
```

#### Type Parameters

`T`<br>

#### Parameters

`obj` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

`key` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

T<br>

### **NullIfWhiteSpace(Object, String)**



```csharp
public static string NullIfWhiteSpace(object value, string key)
```

#### Parameters

`value` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

`key` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

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

---

[`< Back`](./)
