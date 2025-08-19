[`< Back`](./)

---

# ModularBaseDbUtility&lt;TModularDbClient, TInterface, TModel&gt;

Namespace: Jlw.Utilities.Data.DbUtility

```csharp
public class ModularBaseDbUtility<TModularDbClient, TInterface, TModel> : ModularDataRepositoryBase`2, IModularDataRepositoryBase`2, IModularDbUtility
```

#### Type Parameters

`TModularDbClient`<br>

`TInterface`<br>

`TModel`<br>

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → ModularDataRepositoryBase&lt;TInterface, TModel&gt; → [ModularBaseDbUtility&lt;TModularDbClient, TInterface, TModel&gt;](./jlw.utilities.data.dbutility.modularbasedbutility-3.md)<br>
Implements IModularDataRepositoryBase&lt;TInterface, TModel&gt;, [IModularDbUtility](./jlw.utilities.data.dbutility.imodulardbutility.md)

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

### **ModularBaseDbUtility()**

```csharp
public ModularBaseDbUtility()
```

### **ModularBaseDbUtility(String)**

```csharp
public ModularBaseDbUtility(string sType)
```

#### Parameters

`sType` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **ModularBaseDbUtility(String, String, TModularDbClient)**

```csharp
public ModularBaseDbUtility(string sType, string connString, TModularDbClient dbClient)
```

#### Parameters

`sType` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`connString` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`dbClient` TModularDbClient<br>

## Methods

### **GetDatabaseList()**

```csharp
public IEnumerable<IDatabaseSchema> GetDatabaseList()
```

#### Returns

[IEnumerable&lt;IDatabaseSchema&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>

### **GetDatabaseList(String)**

```csharp
public IEnumerable<IDatabaseSchema> GetDatabaseList(string connString)
```

#### Parameters

`connString` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[IEnumerable&lt;IDatabaseSchema&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>

### **GetDatabaseSchema(String)**

```csharp
public IDatabaseSchema GetDatabaseSchema(string dbName)
```

#### Parameters

`dbName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[IDatabaseSchema](./jlw.utilities.data.dbutility.idatabaseschema.md)<br>

### **GetDatabaseSchema(String, String)**

```csharp
public IDatabaseSchema GetDatabaseSchema(string connString, string dbName)
```

#### Parameters

`connString` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`dbName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[IDatabaseSchema](./jlw.utilities.data.dbutility.idatabaseschema.md)<br>

### **GetTableColumns(String, String)**

```csharp
public IEnumerable<IColumnSchema> GetTableColumns(string dbName, string tableName)
```

#### Parameters

`dbName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`tableName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[IEnumerable&lt;IColumnSchema&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>

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

### **GetTableList(String)**

```csharp
public IEnumerable<ITableSchema> GetTableList(string dbName)
```

#### Parameters

`dbName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[IEnumerable&lt;ITableSchema&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>

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
