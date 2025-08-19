[`< Back`](./)

---

# IModularDbUtility

Namespace: Jlw.Utilities.Data.DbUtility

Interface IModularDbUtility

```csharp
public interface IModularDbUtility
```

## Properties

### **DbType**

```csharp
public abstract string DbType { get; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **ConnectionStringBuilder**

```csharp
public abstract DbConnectionStringBuilder ConnectionStringBuilder { get; }
```

#### Property Value

DbConnectionStringBuilder<br>

## Methods

### **GetDatabaseList()**

```csharp
IEnumerable<IDatabaseSchema> GetDatabaseList()
```

#### Returns

[IEnumerable&lt;IDatabaseSchema&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>

### **GetDatabaseList(String)**

```csharp
IEnumerable<IDatabaseSchema> GetDatabaseList(string connString)
```

#### Parameters

`connString` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[IEnumerable&lt;IDatabaseSchema&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>

### **GetDatabaseSchema(String)**

```csharp
IDatabaseSchema GetDatabaseSchema(string dbName)
```

#### Parameters

`dbName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[IDatabaseSchema](./jlw.utilities.data.dbutility.idatabaseschema.md)<br>

### **GetDatabaseSchema(String, String)**

```csharp
IDatabaseSchema GetDatabaseSchema(string connString, string dbName)
```

#### Parameters

`connString` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`dbName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[IDatabaseSchema](./jlw.utilities.data.dbutility.idatabaseschema.md)<br>

### **GetTableColumns(String, String)**

```csharp
IEnumerable<IColumnSchema> GetTableColumns(string dbName, string tableName)
```

#### Parameters

`dbName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`tableName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[IEnumerable&lt;IColumnSchema&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>

### **GetTableColumns(String, String, String)**

```csharp
IEnumerable<IColumnSchema> GetTableColumns(string connString, string dbName, string tableName)
```

#### Parameters

`connString` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`dbName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`tableName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[IEnumerable&lt;IColumnSchema&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>

### **GetTableList(String)**

```csharp
IEnumerable<ITableSchema> GetTableList(string dbName)
```

#### Parameters

`dbName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[IEnumerable&lt;ITableSchema&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>

### **GetTableList(String, String)**

```csharp
IEnumerable<ITableSchema> GetTableList(string connString, string dbName)
```

#### Parameters

`connString` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`dbName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[IEnumerable&lt;ITableSchema&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>

### **GetConnectionString(String, String)**

```csharp
string GetConnectionString(string serverName, string dbName)
```

#### Parameters

`serverName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`dbName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

---

[`< Back`](./)
