[`< Back`](./)

---

# IModularDbOptions

Namespace: Jlw.Utilities.Data.DbUtility

Settings for a ModularDb repository

```csharp
public interface IModularDbOptions
```

## Properties

### **DbClient**

Gets or sets the database client.

```csharp
public abstract IModularDbClient DbClient { get; set; }
```

#### Property Value

[IModularDbClient](./jlw.utilities.data.dbutility.imodulardbclient.md)<br>
The database client.

### **ConnectionString**

Gets or sets the connection string.

```csharp
public abstract string ConnectionString { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The connection string.

### **CommandTimeout**

Gets or sets the amount of time an IDbCommand has to execute. (defaults to 30 seconds)

```csharp
public abstract int CommandTimeout { get; set; }
```

#### Property Value

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The command timeout in seconds.

---

[`< Back`](./)
