[`< Back`](./)

---

# NullDbCommand

Namespace: Jlw.Utilities.Data.DbUtility

```csharp
public class NullDbCommand : NullDbCommand`1, System.Data.IDbCommand, System.IDisposable
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [NullDbCommand&lt;NullDbParameter&gt;](./jlw.utilities.data.dbutility.nulldbcommand-1.md) → [NullDbCommand](./jlw.utilities.data.dbutility.nulldbcommand.md)<br>
Implements IDbCommand, [IDisposable](https://docs.microsoft.com/en-us/dotnet/api/system.idisposable)

## Properties

### **CommandText**

```csharp
public string CommandText { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **CommandTimeout**

```csharp
public int CommandTimeout { get; set; }
```

#### Property Value

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

### **CommandType**

```csharp
public CommandType CommandType { get; set; }
```

#### Property Value

CommandType<br>

### **Connection**

```csharp
public IDbConnection Connection { get; set; }
```

#### Property Value

IDbConnection<br>

### **Parameters**

```csharp
public IDataParameterCollection Parameters { get; }
```

#### Property Value

IDataParameterCollection<br>

### **Transaction**

```csharp
public IDbTransaction Transaction { get; set; }
```

#### Property Value

IDbTransaction<br>

### **UpdatedRowSource**

```csharp
public UpdateRowSource UpdatedRowSource { get; set; }
```

#### Property Value

UpdateRowSource<br>

## Constructors

### **NullDbCommand()**

```csharp
public NullDbCommand()
```

---

[`< Back`](./)
