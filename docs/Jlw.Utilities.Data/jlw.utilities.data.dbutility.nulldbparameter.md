[`< Back`](./)

---

# NullDbParameter

Namespace: Jlw.Utilities.Data.DbUtility

```csharp
public class NullDbParameter : MockDbParameter, System.Data.IDbDataParameter, System.Data.IDataParameter
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [MockDbParameter](./jlw.utilities.data.dbutility.mockdbparameter.md) → [NullDbParameter](./jlw.utilities.data.dbutility.nulldbparameter.md)<br>
Implements IDbDataParameter, IDataParameter

## Properties

### **DbType**

```csharp
public DbType DbType { get; set; }
```

#### Property Value

DbType<br>

### **Direction**

```csharp
public ParameterDirection Direction { get; set; }
```

#### Property Value

ParameterDirection<br>

### **IsNullable**

```csharp
public bool IsNullable { get; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **ParameterName**

```csharp
public string ParameterName { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **SourceColumn**

```csharp
public string SourceColumn { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **SourceVersion**

```csharp
public DataRowVersion SourceVersion { get; set; }
```

#### Property Value

DataRowVersion<br>

### **Value**

```csharp
public object Value { get; set; }
```

#### Property Value

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

### **Precision**

```csharp
public byte Precision { get; set; }
```

#### Property Value

[Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte)<br>

### **Scale**

```csharp
public byte Scale { get; set; }
```

#### Property Value

[Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte)<br>

### **Size**

```csharp
public int Size { get; set; }
```

#### Property Value

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

## Constructors

### **NullDbParameter()**

```csharp
public NullDbParameter()
```

---

[`< Back`](./)
