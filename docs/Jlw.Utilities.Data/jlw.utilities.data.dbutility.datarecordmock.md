[`< Back`](./)

---

# DataRecordMock

Namespace: Jlw.Utilities.Data.DbUtility

```csharp
public class DataRecordMock : System.Data.IDataRecord
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [DataRecordMock](./jlw.utilities.data.dbutility.datarecordmock.md)<br>
Implements IDataRecord<br>
Attributes [DefaultMemberAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.reflection.defaultmemberattribute)

## Properties

### **FieldCount**

```csharp
public int FieldCount { get; }
```

#### Property Value

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

### **Item**

```csharp
public object Item { get; }
```

#### Property Value

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

### **Item**

```csharp
public object Item { get; set; }
```

#### Property Value

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

## Constructors

### **DataRecordMock()**

```csharp
public DataRecordMock()
```

## Methods

### **Add(String, Object)**

```csharp
public void Add(string name, object o)
```

#### Parameters

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`o` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

### **GetBoolean(Int32)**

```csharp
public bool GetBoolean(int i)
```

#### Parameters

`i` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **GetByte(Int32)**

```csharp
public byte GetByte(int i)
```

#### Parameters

`i` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

#### Returns

[Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte)<br>

### **GetBytes(Int32, Int64, Byte[], Int32, Int32)**

```csharp
public long GetBytes(int i, long fieldOffset, Byte[] buffer, int bufferoffset, int length)
```

#### Parameters

`i` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

`fieldOffset` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>

`buffer` [Byte[]](https://docs.microsoft.com/en-us/dotnet/api/system.byte)<br>

`bufferoffset` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

`length` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

#### Returns

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>

### **GetChar(Int32)**

```csharp
public char GetChar(int i)
```

#### Parameters

`i` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

#### Returns

[Char](https://docs.microsoft.com/en-us/dotnet/api/system.char)<br>

### **GetChars(Int32, Int64, Char[], Int32, Int32)**

```csharp
public long GetChars(int i, long fieldoffset, Char[] buffer, int bufferoffset, int length)
```

#### Parameters

`i` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

`fieldoffset` [Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>

`buffer` [Char[]](https://docs.microsoft.com/en-us/dotnet/api/system.char)<br>

`bufferoffset` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

`length` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

#### Returns

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>

### **GetData(Int32)**

```csharp
public IDataReader GetData(int i)
```

#### Parameters

`i` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

#### Returns

IDataReader<br>

### **GetDataTypeName(Int32)**

```csharp
public string GetDataTypeName(int i)
```

#### Parameters

`i` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **GetDateTime(Int32)**

```csharp
public DateTime GetDateTime(int i)
```

#### Parameters

`i` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

#### Returns

[DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime)<br>

### **GetDecimal(Int32)**

```csharp
public decimal GetDecimal(int i)
```

#### Parameters

`i` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

#### Returns

[Decimal](https://docs.microsoft.com/en-us/dotnet/api/system.decimal)<br>

### **GetDouble(Int32)**

```csharp
public double GetDouble(int i)
```

#### Parameters

`i` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

#### Returns

[Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>

### **GetFieldType(Int32)**

```csharp
public Type GetFieldType(int i)
```

#### Parameters

`i` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

#### Returns

[Type](https://docs.microsoft.com/en-us/dotnet/api/system.type)<br>

### **GetFloat(Int32)**

```csharp
public float GetFloat(int i)
```

#### Parameters

`i` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

#### Returns

[Single](https://docs.microsoft.com/en-us/dotnet/api/system.single)<br>

### **GetGuid(Int32)**

```csharp
public Guid GetGuid(int i)
```

#### Parameters

`i` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

#### Returns

[Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid)<br>

### **GetInt16(Int32)**

```csharp
public short GetInt16(int i)
```

#### Parameters

`i` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

#### Returns

[Int16](https://docs.microsoft.com/en-us/dotnet/api/system.int16)<br>

### **GetInt32(Int32)**

```csharp
public int GetInt32(int i)
```

#### Parameters

`i` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

#### Returns

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

### **GetInt64(Int32)**

```csharp
public long GetInt64(int i)
```

#### Parameters

`i` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

#### Returns

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>

### **GetName(Int32)**

```csharp
public string GetName(int i)
```

#### Parameters

`i` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **GetOrdinal(String)**

```csharp
public int GetOrdinal(string name)
```

#### Parameters

`name` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

### **GetString(Int32)**

```csharp
public string GetString(int i)
```

#### Parameters

`i` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **GetValue(Int32)**

```csharp
public object GetValue(int i)
```

#### Parameters

`i` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

#### Returns

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

### **GetValues(Object[])**

```csharp
public int GetValues(Object[] values)
```

#### Parameters

`values` [Object[]](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

#### Returns

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

### **IsDBNull(Int32)**

```csharp
public bool IsDBNull(int i)
```

#### Parameters

`i` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

---

[`< Back`](./)
