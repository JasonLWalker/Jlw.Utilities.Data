[`< Back`](./)

---

# IModularDataRepository&lt;TInterface, TModel&gt;

Namespace: Jlw.Utilities.Data.DbUtility

Interface IModularDataRepository

```csharp
public interface IModularDataRepository<TInterface, TModel>
```

#### Type Parameters

`TInterface`<br>
The type of the t interface.

`TModel`<br>
The type of the t model.

## Properties

### **ConnectionString**

```csharp
public abstract string ConnectionString { get; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **ConnectionBuilder**

```csharp
public abstract DbConnectionStringBuilder ConnectionBuilder { get; }
```

#### Property Value

DbConnectionStringBuilder<br>

### **DbClient**

```csharp
public abstract IModularDbClient DbClient { get; }
```

#### Property Value

[IModularDbClient](./jlw.utilities.data.dbutility.imodulardbclient.md)<br>

---

[`< Back`](./)
