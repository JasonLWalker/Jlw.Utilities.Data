[`< Back`](./)

---

# ModularDataRepositoryBase&lt;TInterface, TModel&gt;

Namespace: Jlw.Utilities.Data.DbUtility

```csharp
public class ModularDataRepositoryBase<TInterface, TModel> : IModularDataRepositoryBase`2
```

#### Type Parameters

`TInterface`<br>

`TModel`<br>

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [ModularDataRepositoryBase&lt;TInterface, TModel&gt;](./jlw.utilities.data.dbutility.modulardatarepositorybase-2.md)<br>
Implements IModularDataRepositoryBase&lt;TInterface, TModel&gt;

## Constructors

### **ModularDataRepositoryBase(IModularDbOptions)**

```csharp
public ModularDataRepositoryBase(IModularDbOptions opts)
```

#### Parameters

`opts` [IModularDbOptions](./jlw.utilities.data.dbutility.imodulardboptions.md)<br>

### **ModularDataRepositoryBase(IModularDbClient, String)**

```csharp
public ModularDataRepositoryBase(IModularDbClient dbClient, string connString)
```

#### Parameters

`dbClient` [IModularDbClient](./jlw.utilities.data.dbutility.imodulardbclient.md)<br>

`connString` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

## Methods

### **GetRecord(TInterface)**

```csharp
public TInterface GetRecord(TInterface o)
```

#### Parameters

`o` TInterface<br>

#### Returns

TInterface<br>

### **GetAllRecords()**

```csharp
public IEnumerable<TInterface> GetAllRecords()
```

#### Returns

IEnumerable&lt;TInterface&gt;<br>

### **InsertRecord(TInterface)**

```csharp
public TInterface InsertRecord(TInterface o)
```

#### Parameters

`o` TInterface<br>

#### Returns

TInterface<br>

### **SaveRecord(TInterface)**

```csharp
public TInterface SaveRecord(TInterface o)
```

#### Parameters

`o` TInterface<br>

#### Returns

TInterface<br>

### **UpdateRecord(TInterface)**

```csharp
public TInterface UpdateRecord(TInterface o)
```

#### Parameters

`o` TInterface<br>

#### Returns

TInterface<br>

### **DeleteRecord(TInterface)**

```csharp
public TInterface DeleteRecord(TInterface o)
```

#### Parameters

`o` TInterface<br>

#### Returns

TInterface<br>

### **GetKvpList(String, String)**

```csharp
public IEnumerable<KeyValuePair<string, string>> GetKvpList(string keyMember, string descMember)
```

#### Parameters

`keyMember` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`descMember` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[IEnumerable&lt;KeyValuePair&lt;String, String&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>

---

[`< Back`](./)
