[`< Back`](./)

---

# JlwJsonConverter

Namespace: Jlw.Utilities.Data

```csharp
public class JlwJsonConverter : Newtonsoft.Json.JsonConverter
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → JsonConverter → [JlwJsonConverter](./jlw.utilities.data.jlwjsonconverter.md)

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

### **JlwJsonConverter()**

```csharp
public JlwJsonConverter()
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
