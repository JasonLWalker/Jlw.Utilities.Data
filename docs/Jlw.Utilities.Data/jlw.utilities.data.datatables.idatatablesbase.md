[`< Back`](./)

---

# IDataTablesBase

Namespace: Jlw.Utilities.Data.DataTables

Interface IDataTablesBase

```csharp
public interface IDataTablesBase
```

## Properties

### **CommandTimeout**

```csharp
public abstract int CommandTimeout { get; set; }
```

#### Property Value

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

### **Data**

```csharp
public abstract IEnumerable<object> Data { get; }
```

#### Property Value

[IEnumerable&lt;Object&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>

## Methods

### **AddColumn(String, String)**

```csharp
void AddColumn(string columnName, string sqlFragment)
```

#### Parameters

`columnName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`sqlFragment` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **AddExtraParams(String, String)**

```csharp
void AddExtraParams(string columnName, string sqlFragment)
```

#### Parameters

`columnName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`sqlFragment` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **AddSearchColumns(String, String)**

```csharp
void AddSearchColumns(string columnName, string sqlFragment)
```

#### Parameters

`columnName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`sqlFragment` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **AddSortColumns(String, String)**

```csharp
void AddSortColumns(string columnName, string sqlFragment)
```

#### Parameters

`columnName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`sqlFragment` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **FetchData(String, String)**

```csharp
IDataTablesOutput FetchData(string connString, string tables)
```

#### Parameters

`connString` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`tables` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[IDataTablesOutput](./jlw.utilities.data.datatables.idatatablesoutput.md)<br>

### **SetDebug(Boolean)**

```csharp
void SetDebug(bool b)
```

#### Parameters

`b` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **SetGlobalFilter(String)**

```csharp
void SetGlobalFilter(string sqlFragment)
```

#### Parameters

`sqlFragment` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

---

[`< Back`](./)
