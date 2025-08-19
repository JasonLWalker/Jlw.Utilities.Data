[`< Back`](./)

---

# IModularDataRepositoryBase&lt;TInterface, TModel&gt;

Namespace: Jlw.Utilities.Data.DbUtility

Interface IModularDataRepositoryBase

```csharp
public interface IModularDataRepositoryBase<TInterface, TModel>
```

#### Type Parameters

`TInterface`<br>
The type of the t interface.

`TModel`<br>
The type of the t model.

## Methods

### **GetRecord(TInterface)**

```csharp
TInterface GetRecord(TInterface o)
```

#### Parameters

`o` TInterface<br>

#### Returns

TInterface<br>

### **GetAllRecords()**

```csharp
IEnumerable<TInterface> GetAllRecords()
```

#### Returns

IEnumerable&lt;TInterface&gt;<br>

### **InsertRecord(TInterface)**

```csharp
TInterface InsertRecord(TInterface o)
```

#### Parameters

`o` TInterface<br>

#### Returns

TInterface<br>

### **SaveRecord(TInterface)**

```csharp
TInterface SaveRecord(TInterface o)
```

#### Parameters

`o` TInterface<br>

#### Returns

TInterface<br>

### **UpdateRecord(TInterface)**

```csharp
TInterface UpdateRecord(TInterface o)
```

#### Parameters

`o` TInterface<br>

#### Returns

TInterface<br>

### **DeleteRecord(TInterface)**

```csharp
TInterface DeleteRecord(TInterface o)
```

#### Parameters

`o` TInterface<br>

#### Returns

TInterface<br>

### **GetKvpList(String, String)**

```csharp
IEnumerable<KeyValuePair<string, string>> GetKvpList(string keyMember, string descMember)
```

#### Parameters

`keyMember` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`descMember` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[IEnumerable&lt;KeyValuePair&lt;String, String&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>

---

[`< Back`](./)
