[`< Back`](./)

---

# ModularDataRepository&lt;TInterface, TModel&gt;

Namespace: Jlw.Utilities.Data.DbUtility

```csharp
public class ModularDataRepository<TInterface, TModel> : IModularDataRepository`2
```

#### Type Parameters

`TInterface`<br>

`TModel`<br>

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [ModularDataRepository&lt;TInterface, TModel&gt;](./jlw.utilities.data.dbutility.modulardatarepository-2.md)<br>
Implements IModularDataRepository&lt;TInterface, TModel&gt;

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
