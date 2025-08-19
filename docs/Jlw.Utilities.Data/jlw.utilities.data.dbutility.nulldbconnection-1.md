[`< Back`](./)

---

# NullDbConnection&lt;TCommand&gt;

Namespace: Jlw.Utilities.Data.DbUtility

```csharp
public class NullDbConnection<TCommand> : System.Data.IDbConnection, System.IDisposable
```

#### Type Parameters

`TCommand`<br>

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [NullDbConnection&lt;TCommand&gt;](./jlw.utilities.data.dbutility.nulldbconnection-1.md)<br>
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
