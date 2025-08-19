[`< Back`](./)

---

# MockDbConnection&lt;TCommand&gt;

Namespace: Jlw.Utilities.Data.DbUtility

```csharp
public class MockDbConnection<TCommand> : System.Data.IDbConnection, System.IDisposable
```

#### Type Parameters

`TCommand`<br>

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [MockDbConnection&lt;TCommand&gt;](./jlw.utilities.data.dbutility.mockdbconnection-1.md)<br>
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

## Methods

### **Dispose()**

```csharp
public void Dispose()
```

### **BeginTransaction()**

```csharp
public IDbTransaction BeginTransaction()
```

#### Returns

IDbTransaction<br>

### **BeginTransaction(IsolationLevel)**

```csharp
public IDbTransaction BeginTransaction(IsolationLevel il)
```

#### Parameters

`il` IsolationLevel<br>

#### Returns

IDbTransaction<br>

### **ChangeDatabase(String)**

```csharp
public void ChangeDatabase(string databaseName)
```

#### Parameters

`databaseName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Close()**

```csharp
public void Close()
```

### **CreateCommand()**

```csharp
public IDbCommand CreateCommand()
```

#### Returns

IDbCommand<br>

### **Open()**

```csharp
public void Open()
```

---

[`< Back`](./)
