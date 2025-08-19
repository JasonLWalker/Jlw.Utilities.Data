[`< Back`](./)

---

# ModularDataRepository

Namespace: Jlw.Utilities.Data.DbUtility

```csharp
public class ModularDataRepository : ModularDataRepository`2, IModularDataRepository`2
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [ModularDataRepository&lt;Object, Object&gt;](./jlw.utilities.data.dbutility.modulardatarepository-2.md) → [ModularDataRepository](./jlw.utilities.data.dbutility.modulardatarepository.md)<br>
Implements [IModularDataRepository&lt;Object, Object&gt;](./jlw.utilities.data.dbutility.imodulardatarepository-2.md)

## Properties

### **ConnectionBuilder**

```csharp
public DbConnectionStringBuilder ConnectionBuilder { get; }
```

#### Property Value

DbConnectionStringBuilder<br>

### **ConnectionString**

```csharp
public string ConnectionString { get; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **DbClient**

```csharp
public IModularDbClient DbClient { get; }
```

#### Property Value

[IModularDbClient](./jlw.utilities.data.dbutility.imodulardbclient.md)<br>

## Constructors

### **ModularDataRepository(IModularDbOptions)**

```csharp
public ModularDataRepository(IModularDbOptions opts)
```

#### Parameters

`opts` [IModularDbOptions](./jlw.utilities.data.dbutility.imodulardboptions.md)<br>

### **ModularDataRepository(IModularDbClient, String)**

```csharp
public ModularDataRepository(IModularDbClient dbClient, string connString)
```

#### Parameters

`dbClient` [IModularDbClient](./jlw.utilities.data.dbutility.imodulardbclient.md)<br>

`connString` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

---

[`< Back`](./)
