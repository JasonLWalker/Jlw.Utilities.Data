[`< Back`](./)

---

# MockDbConnection

Namespace: Jlw.Utilities.Data.DbUtility

```csharp
public class MockDbConnection : MockDbConnection`1, System.Data.IDbConnection, System.IDisposable
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [MockDbConnection&lt;NullDbCommand&gt;](./jlw.utilities.data.dbutility.mockdbconnection-1.md) → [MockDbConnection](./jlw.utilities.data.dbutility.mockdbconnection.md)<br>
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
public string Database { get; protected set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **State**

```csharp
public ConnectionState State { get; protected set; }
```

#### Property Value

ConnectionState<br>

## Constructors

### **MockDbConnection()**

```csharp
public MockDbConnection()
```

---

[`< Back`](./)
