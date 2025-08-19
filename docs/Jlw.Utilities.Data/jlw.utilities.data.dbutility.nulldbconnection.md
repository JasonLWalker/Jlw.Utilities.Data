[`< Back`](./)

---

# NullDbConnection

Namespace: Jlw.Utilities.Data.DbUtility

```csharp
public class NullDbConnection : NullDbConnection`1, System.Data.IDbConnection, System.IDisposable
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [NullDbConnection&lt;NullDbCommand&gt;](./jlw.utilities.data.dbutility.nulldbconnection-1.md) → [NullDbConnection](./jlw.utilities.data.dbutility.nulldbconnection.md)<br>
Implements IDbConnection, [IDisposable](https://docs.microsoft.com/en-us/dotnet/api/system.idisposable)

## Properties

### **ConnectionString**

```csharp
public string ConnectionString { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **ConnectionTimeout**

```csharp
public int ConnectionTimeout { get; }
```

#### Property Value

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

### **Database**

```csharp
public string Database { get; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **State**

```csharp
public ConnectionState State { get; }
```

#### Property Value

ConnectionState<br>

## Constructors

### **NullDbConnection()**

```csharp
public NullDbConnection()
```

---

[`< Back`](./)
