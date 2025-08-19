[`< Back`](./)

---

# ModularDbClient&lt;TConnection&gt;

Namespace: Jlw.Utilities.Data.DbUtility

```csharp
public class ModularDbClient<TConnection> : IModularDbClient
```

#### Type Parameters

`TConnection`<br>

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [ModularDbClient&lt;TConnection&gt;](./jlw.utilities.data.dbutility.modulardbclient-1.md)<br>
Implements [IModularDbClient](./jlw.utilities.data.dbutility.imodulardbclient.md)

## Properties

### **CommandTimeout**

```csharp
public int CommandTimeout { get; set; }
```

#### Property Value

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

## Constructors

### **ModularDbClient()**

```csharp
public ModularDbClient()
```

## Methods

### **GetConnectionBuilder(String)**

```csharp
public DbConnectionStringBuilder GetConnectionBuilder(string connString)
```

#### Parameters

`connString` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

DbConnectionStringBuilder<br>

### **GetConnection(String)**

```csharp
public IDbConnection GetConnection(string connString)
```

#### Parameters

`connString` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

IDbConnection<br>

### **GetCommand(String, IDbConnection)**

```csharp
public IDbCommand GetCommand(string cmd, IDbConnection conn)
```

#### Parameters

`cmd` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`conn` IDbConnection<br>

#### Returns

IDbCommand<br>

### **AddParameter(IDbDataParameter, IDbCommand)**

```csharp
public IDbDataParameter AddParameter(IDbDataParameter param, IDbCommand cmd)
```

#### Parameters

`param` IDbDataParameter<br>

`cmd` IDbCommand<br>

#### Returns

IDbDataParameter<br>

### **AddParameterWithValue(String, Object, IDbCommand)**

```csharp
public IDbDataParameter AddParameterWithValue(string paramName, object value, IDbCommand cmd)
```

#### Parameters

`paramName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`value` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

`cmd` IDbCommand<br>

#### Returns

IDbDataParameter<br>

### **GetNewParameter(IDbDataParameter, IDbCommand)**

```csharp
public IDbDataParameter GetNewParameter(IDbDataParameter param, IDbCommand cmd)
```

#### Parameters

`param` IDbDataParameter<br>

`cmd` IDbCommand<br>

#### Returns

IDbDataParameter<br>

### **ExecuteNonQuery(String, IRepositoryMethodDefinition)**

```csharp
public int ExecuteNonQuery(string connString, IRepositoryMethodDefinition definition)
```

#### Parameters

`connString` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`definition` [IRepositoryMethodDefinition](./jlw.utilities.data.dbutility.irepositorymethoddefinition.md)<br>

#### Returns

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

### **ExecuteNonQuery(Object, String, IRepositoryMethodDefinition)**

```csharp
public int ExecuteNonQuery(object o, string connString, IRepositoryMethodDefinition definition)
```

#### Parameters

`o` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

`connString` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`definition` [IRepositoryMethodDefinition](./jlw.utilities.data.dbutility.irepositorymethoddefinition.md)<br>

#### Returns

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

### **GetRecordObject&lt;TReturn&gt;(String, IRepositoryMethodDefinition)**

```csharp
public TReturn GetRecordObject<TReturn>(string connString, IRepositoryMethodDefinition definition)
```

#### Type Parameters

`TReturn`<br>

#### Parameters

`connString` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`definition` [IRepositoryMethodDefinition](./jlw.utilities.data.dbutility.irepositorymethoddefinition.md)<br>

#### Returns

TReturn<br>

### **GetRecordObject&lt;TReturn&gt;(Object, String, IRepositoryMethodDefinition)**

```csharp
public TReturn GetRecordObject<TReturn>(object o, string connString, IRepositoryMethodDefinition definition)
```

#### Type Parameters

`TReturn`<br>

#### Parameters

`o` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

`connString` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`definition` [IRepositoryMethodDefinition](./jlw.utilities.data.dbutility.irepositorymethoddefinition.md)<br>

#### Returns

TReturn<br>

### **GetRecordScalar&lt;TReturn&gt;(String, IRepositoryMethodDefinition)**

```csharp
public TReturn GetRecordScalar<TReturn>(string connString, IRepositoryMethodDefinition definition)
```

#### Type Parameters

`TReturn`<br>

#### Parameters

`connString` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`definition` [IRepositoryMethodDefinition](./jlw.utilities.data.dbutility.irepositorymethoddefinition.md)<br>

#### Returns

TReturn<br>

### **GetRecordScalar&lt;TReturn&gt;(Object, String, IRepositoryMethodDefinition)**

```csharp
public TReturn GetRecordScalar<TReturn>(object o, string connString, IRepositoryMethodDefinition definition)
```

#### Type Parameters

`TReturn`<br>

#### Parameters

`o` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

`connString` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`definition` [IRepositoryMethodDefinition](./jlw.utilities.data.dbutility.irepositorymethoddefinition.md)<br>

#### Returns

TReturn<br>

### **GetRecordList&lt;TReturn&gt;(String, IRepositoryMethodDefinition)**

```csharp
public IEnumerable<TReturn> GetRecordList<TReturn>(string connString, IRepositoryMethodDefinition definition)
```

#### Type Parameters

`TReturn`<br>

#### Parameters

`connString` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`definition` [IRepositoryMethodDefinition](./jlw.utilities.data.dbutility.irepositorymethoddefinition.md)<br>

#### Returns

IEnumerable&lt;TReturn&gt;<br>

### **GetRecordList&lt;TReturn&gt;(Object, String, IRepositoryMethodDefinition)**

```csharp
public IEnumerable<TReturn> GetRecordList<TReturn>(object o, string connString, IRepositoryMethodDefinition definition)
```

#### Type Parameters

`TReturn`<br>

#### Parameters

`o` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

`connString` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`definition` [IRepositoryMethodDefinition](./jlw.utilities.data.dbutility.irepositorymethoddefinition.md)<br>

#### Returns

IEnumerable&lt;TReturn&gt;<br>

---

[`< Back`](./)
