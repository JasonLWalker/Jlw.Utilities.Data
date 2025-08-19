[`< Back`](./)

---

# IModularDbClient

Namespace: Jlw.Utilities.Data.DbUtility

Interface IModularDbClient

```csharp
public interface IModularDbClient
```

## Properties

### **CommandTimeout**

```csharp
public abstract int CommandTimeout { get; set; }
```

#### Property Value

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

## Methods

### **GetConnectionBuilder(String)**

```csharp
DbConnectionStringBuilder GetConnectionBuilder(string connString)
```

#### Parameters

`connString` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

DbConnectionStringBuilder<br>

### **GetConnection(String)**

```csharp
IDbConnection GetConnection(string connString)
```

#### Parameters

`connString` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

IDbConnection<br>

### **GetCommand(String, IDbConnection)**

```csharp
IDbCommand GetCommand(string cmd, IDbConnection conn)
```

#### Parameters

`cmd` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`conn` IDbConnection<br>

#### Returns

IDbCommand<br>

### **AddParameter(IDbDataParameter, IDbCommand)**

```csharp
IDbDataParameter AddParameter(IDbDataParameter param, IDbCommand cmd)
```

#### Parameters

`param` IDbDataParameter<br>

`cmd` IDbCommand<br>

#### Returns

IDbDataParameter<br>

### **AddParameterWithValue(String, Object, IDbCommand)**

```csharp
IDbDataParameter AddParameterWithValue(string paramName, object value, IDbCommand cmd)
```

#### Parameters

`paramName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`value` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

`cmd` IDbCommand<br>

#### Returns

IDbDataParameter<br>

### **GetNewParameter(IDbDataParameter, IDbCommand)**

```csharp
IDbDataParameter GetNewParameter(IDbDataParameter param, IDbCommand cmd)
```

#### Parameters

`param` IDbDataParameter<br>

`cmd` IDbCommand<br>

#### Returns

IDbDataParameter<br>

### **GetRecordScalar&lt;TReturn&gt;(String, IRepositoryMethodDefinition)**

```csharp
TReturn GetRecordScalar<TReturn>(string connString, IRepositoryMethodDefinition definition)
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
TReturn GetRecordScalar<TReturn>(object o, string connString, IRepositoryMethodDefinition definition)
```

#### Type Parameters

`TReturn`<br>

#### Parameters

`o` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

`connString` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`definition` [IRepositoryMethodDefinition](./jlw.utilities.data.dbutility.irepositorymethoddefinition.md)<br>

#### Returns

TReturn<br>

### **GetRecordObject&lt;TReturn&gt;(String, IRepositoryMethodDefinition)**

```csharp
TReturn GetRecordObject<TReturn>(string connString, IRepositoryMethodDefinition definition)
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
TReturn GetRecordObject<TReturn>(object o, string connString, IRepositoryMethodDefinition definition)
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
IEnumerable<TReturn> GetRecordList<TReturn>(string connString, IRepositoryMethodDefinition definition)
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
IEnumerable<TReturn> GetRecordList<TReturn>(object o, string connString, IRepositoryMethodDefinition definition)
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
