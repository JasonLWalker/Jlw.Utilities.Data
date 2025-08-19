[`< Back`](./)

---

# NullDbTransaction

Namespace: Jlw.Utilities.Data.DbUtility

```csharp
public class NullDbTransaction : System.Data.IDbTransaction, System.IDisposable
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [NullDbTransaction](./jlw.utilities.data.dbutility.nulldbtransaction.md)<br>
Implements IDbTransaction, [IDisposable](https://docs.microsoft.com/en-us/dotnet/api/system.idisposable)

## Properties

### **Connection**

```csharp
public IDbConnection Connection { get; }
```

#### Property Value

IDbConnection<br>

### **IsolationLevel**

```csharp
public IsolationLevel IsolationLevel { get; }
```

#### Property Value

IsolationLevel<br>

## Constructors

### **NullDbTransaction(IDbConnection, IsolationLevel)**

```csharp
public NullDbTransaction(IDbConnection c, IsolationLevel il)
```

#### Parameters

`c` IDbConnection<br>

`il` IsolationLevel<br>

## Methods

### **Dispose()**

```csharp
public void Dispose()
```

### **Commit()**

```csharp
public void Commit()
```

### **Rollback()**

```csharp
public void Rollback()
```

---

[`< Back`](./)
