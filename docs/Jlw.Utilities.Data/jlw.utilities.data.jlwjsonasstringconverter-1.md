[`< Back`](./)

---

# JlwJsonAsStringConverter&lt;T&gt;

Namespace: Jlw.Utilities.Data

```csharp
public class JlwJsonAsStringConverter<T> : Newtonsoft.Json.JsonConverter
```

#### Type Parameters

`T`<br>

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → JsonConverter → [JlwJsonAsStringConverter&lt;T&gt;](./jlw.utilities.data.jlwjsonasstringconverter-1.md)

## Properties

### **CanWrite**

```csharp
public bool CanWrite { get; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **CanRead**

```csharp
public bool CanRead { get; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

## Constructors

### **JlwJsonAsStringConverter()**

```csharp
public JlwJsonAsStringConverter()
```

## Methods

### **WriteJson(JsonWriter, Object, JsonSerializer)**

```csharp
public void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
```

#### Parameters

`writer` JsonWriter<br>

`value` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

`serializer` JsonSerializer<br>

### **ReadJson(JsonReader, Type, Object, JsonSerializer)**

```csharp
public object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
```

#### Parameters

`reader` JsonReader<br>

`objectType` [Type](https://docs.microsoft.com/en-us/dotnet/api/system.type)<br>

`existingValue` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

`serializer` JsonSerializer<br>

#### Returns

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

### **CanConvert(Type)**

```csharp
public bool CanConvert(Type objectType)
```

#### Parameters

`objectType` [Type](https://docs.microsoft.com/en-us/dotnet/api/system.type)<br>

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

---

[`< Back`](./)
