[`< Back`](./)

---

# ColumnSchema

Namespace: Jlw.Utilities.Data.DbUtility

```csharp
public class ColumnSchema : IColumnSchema
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [ColumnSchema](./jlw.utilities.data.dbutility.columnschema.md)<br>
Implements [IColumnSchema](./jlw.utilities.data.dbutility.icolumnschema.md)

## Properties

### **Database**

```csharp
public string Database { get; protected set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Schema**

```csharp
public string Schema { get; protected set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Table**

```csharp
public string Table { get; protected set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Name**

```csharp
public string Name { get; protected set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Order**

```csharp
public int Order { get; protected set; }
```

#### Property Value

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

### **DataType**

```csharp
public string DataType { get; protected set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **DefaultValue**

```csharp
public string DefaultValue { get; protected set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **IsAutoNumber**

```csharp
public bool IsAutoNumber { get; protected set; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **IsNullable**

```csharp
public bool IsNullable { get; protected set; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **MaxLength**

```csharp
public Nullable<int> MaxLength { get; protected set; }
```

#### Property Value

[Nullable&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>

### **NumericPrecision**

```csharp
public Nullable<int> NumericPrecision { get; protected set; }
```

#### Property Value

[Nullable&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>

### **NumericScale**

```csharp
public Nullable<int> NumericScale { get; protected set; }
```

#### Property Value

[Nullable&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>

### **Collation**

```csharp
public string Collation { get; protected set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **IsIdentity**

```csharp
public bool IsIdentity { get; protected set; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

## Constructors

### **ColumnSchema(String, String, String, String, Int32, String, String, Boolean, Nullable&lt;Int32&gt;, Nullable&lt;Int32&gt;, Nullable&lt;Int32&gt;, String, Boolean, Boolean)**

```csharp
public ColumnSchema(string sDatabase, string sSchema, string sTable, string sName, int nOrder, string sDataType, string sDefaultValue, bool bIsNullable, Nullable<int> nMaxLength, Nullable<int> nNumericPrecision, Nullable<int> nNumericScale, string sCollation, bool bIsIdentity, bool bIsAutoNumber)
```

#### Parameters

`sDatabase` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`sSchema` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`sTable` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`sName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`nOrder` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

`sDataType` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`sDefaultValue` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`bIsNullable` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

`nMaxLength` [Nullable&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>

`nNumericPrecision` [Nullable&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>

`nNumericScale` [Nullable&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>

`sCollation` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`bIsIdentity` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

`bIsAutoNumber` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **ColumnSchema(IDataRecord)**

```csharp
public ColumnSchema(IDataRecord o)
```

#### Parameters

`o` IDataRecord<br>

### **ColumnSchema(IDictionary&lt;String, Object&gt;)**

```csharp
public ColumnSchema(IDictionary<string, object> o)
```

#### Parameters

`o` [IDictionary&lt;String, Object&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.idictionary-2)<br>

---

[`< Back`](./)
