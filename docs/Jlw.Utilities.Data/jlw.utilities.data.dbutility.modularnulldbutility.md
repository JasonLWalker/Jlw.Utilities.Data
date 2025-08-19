[`< Back`](./)

---

# ModularNullDbUtility

Namespace: Jlw.Utilities.Data.DbUtility

```csharp
public class ModularNullDbUtility : ModularBaseDbUtility, IModularDataRepositoryBase`2, IModularDbUtility
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [ModularDataRepositoryBase&lt;Object, Object&gt;](./jlw.utilities.data.dbutility.modulardatarepositorybase-2.md) → [ModularBaseDbUtility&lt;ModularDbClient&lt;NullDbConnection, NullDbCommand, NullDbParameter&gt;, Object, Object&gt;](./jlw.utilities.data.dbutility.modularbasedbutility-3.md) → [ModularBaseDbUtility](./jlw.utilities.data.dbutility.modularbasedbutility.md) → [ModularNullDbUtility](./jlw.utilities.data.dbutility.modularnulldbutility.md)<br>
Implements [IModularDataRepositoryBase&lt;Object, Object&gt;](./jlw.utilities.data.dbutility.imodulardatarepositorybase-2.md), [IModularDbUtility](./jlw.utilities.data.dbutility.imodulardbutility.md)

## Properties

### **DbType**

```csharp
public string DbType { get; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **ConnectionStringBuilder**

```csharp
public DbConnectionStringBuilder ConnectionStringBuilder { get; }
```

#### Property Value

DbConnectionStringBuilder<br>

## Constructors

### **ModularNullDbUtility()**

```csharp
public ModularNullDbUtility()
```

## Methods

### **GetDatabaseList(String)**

```csharp
public IEnumerable<IDatabaseSchema> GetDatabaseList(string connString)
```

#### Parameters

`connString` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[IEnumerable&lt;IDatabaseSchema&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>

### **GetDatabaseSchema(String, String)**

```csharp
public IDatabaseSchema GetDatabaseSchema(string connString, string dbName)
```

#### Parameters

`connString` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`dbName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[IDatabaseSchema](./jlw.utilities.data.dbutility.idatabaseschema.md)<br>

### **GetTableColumns(String, String, String)**

```csharp
public IEnumerable<IColumnSchema> GetTableColumns(string connString, string dbName, string tableName)
```

#### Parameters

`connString` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`dbName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`tableName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[IEnumerable&lt;IColumnSchema&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>

### **GetTableList(String, String)**

```csharp
public IEnumerable<ITableSchema> GetTableList(string connString, string dbName)
```

#### Parameters

`connString` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`dbName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[IEnumerable&lt;ITableSchema&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>

### **GetConnectionString(String, String)**

```csharp
public string GetConnectionString(string serverName, string dbName)
```

#### Parameters

`serverName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`dbName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

---

[`< Back`](./)
