[`< Back`](./)

---

# NullDbCommand&lt;TParam&gt;

Namespace: Jlw.Utilities.Data.DbUtility

```csharp
public class NullDbCommand<TParam> : System.Data.IDbCommand, System.IDisposable
```

#### Type Parameters

`TParam`<br>

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [NullDbCommand&lt;TParam&gt;](./jlw.utilities.data.dbutility.nulldbcommand-1.md)<br>
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

## Methods

### **Dispose()**

```csharp
public void Dispose()
```

### **Cancel()**

```csharp
public void Cancel()
```

### **CreateParameter()**

```csharp
public IDbDataParameter CreateParameter()
```

#### Returns

IDbDataParameter<br>

### **ExecuteNonQuery()**

```csharp
public int ExecuteNonQuery()
```

#### Returns

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

### **ExecuteReader()**

```csharp
public IDataReader ExecuteReader()
```

#### Returns

IDataReader<br>

### **ExecuteReader(CommandBehavior)**

```csharp
public IDataReader ExecuteReader(CommandBehavior behavior)
```

#### Parameters

`behavior` CommandBehavior<br>

#### Returns

IDataReader<br>

### **ExecuteScalar()**

```csharp
public object ExecuteScalar()
```

#### Returns

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

### **Prepare()**

```csharp
public void Prepare()
```

---

[`< Back`](./)
