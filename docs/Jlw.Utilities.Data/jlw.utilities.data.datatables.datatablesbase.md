[`< Back`](./)

---

# DataTablesBase

Namespace: Jlw.Utilities.Data.DataTables

```csharp
public class DataTablesBase : IDataTablesBase
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [DataTablesBase](./jlw.utilities.data.datatables.datatablesbase.md)<br>
Implements [IDataTablesBase](./jlw.utilities.data.datatables.idatatablesbase.md)

## Properties

### **CommandTimeout**

```csharp
public int CommandTimeout { get; set; }
```

#### Property Value

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

### **Data**

```csharp
public IEnumerable<object> Data { get; }
```

#### Property Value

[IEnumerable&lt;Object&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>

### **UseOrderedPaging**

```csharp
public bool UseOrderedPaging { get; set; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

## Constructors

### **DataTablesBase(IDataTablesInput, IModularDbClient)**

```csharp
public DataTablesBase(IDataTablesInput input, IModularDbClient dbClient)
```

#### Parameters

`input` [IDataTablesInput](./jlw.utilities.data.datatables.idatatablesinput.md)<br>

`dbClient` [IModularDbClient](./jlw.utilities.data.dbutility.imodulardbclient.md)<br>

## Methods

### **SetDebug(Boolean)**

```csharp
public void SetDebug(bool b)
```

#### Parameters

`b` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **AddColumn(String, String)**

Adds a Column to the Valid Column list.

```csharp
public void AddColumn(string columnName, string sqlFragment)
```

#### Parameters

`columnName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The name of the column. This will be used as both the column name in the output, and the column name in the generated SQL Query.

`sqlFragment` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The fragment of SQL code used to generate this column. This can be as simple as a table column name, or as complex as a SQL subquery.

### **SetGlobalFilter(String)**

```csharp
public void SetGlobalFilter(string sqlFragment)
```

#### Parameters

`sqlFragment` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **AddExtraParams(String, String)**

```csharp
public void AddExtraParams(string columnName, string sqlFragment)
```

#### Parameters

`columnName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`sqlFragment` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **AddSearchColumns(String, String)**

```csharp
public void AddSearchColumns(string columnName, string sqlFragment)
```

#### Parameters

`columnName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`sqlFragment` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **AddSortColumns(String, String)**

```csharp
public void AddSortColumns(string columnName, string sqlFragment)
```

#### Parameters

`columnName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`sqlFragment` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **FetchQuery(String, String)**

```csharp
public IDataTablesOutput FetchQuery(string connString, string sSql)
```

#### Parameters

`connString` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`sSql` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[IDataTablesOutput](./jlw.utilities.data.datatables.idatatablesoutput.md)<br>

### **FetchData(String, String)**

```csharp
public IDataTablesOutput FetchData(string connString, string tables)
```

#### Parameters

`connString` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`tables` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[IDataTablesOutput](./jlw.utilities.data.datatables.idatatablesoutput.md)<br>

---

[`< Back`](./)
