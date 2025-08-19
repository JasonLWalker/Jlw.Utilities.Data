[`< Back`](./)

---

# QueryMethodDefinition&lt;TModel&gt;

Namespace: Jlw.Utilities.Data.DbUtility

```csharp
public class QueryMethodDefinition<TModel> : RepositoryMethodDefinition`2, IRepositoryMethodDefinition
```

#### Type Parameters

`TModel`<br>

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → RepositoryMethodDefinition&lt;TModel, TModel&gt; → [QueryMethodDefinition&lt;TModel&gt;](./jlw.utilities.data.dbutility.querymethoddefinition-1.md)<br>
Implements [IRepositoryMethodDefinition](./jlw.utilities.data.dbutility.irepositorymethoddefinition.md)

## Fields

### **InterfaceType**

```csharp
public Type InterfaceType;
```

### **ModelType**

```csharp
public Type ModelType;
```

### **ReturnType**

```csharp
public Type ReturnType;
```

## Properties

### **Parameters**

```csharp
public IEnumerable<IDbDataParameter> Parameters { get; }
```

#### Property Value

[IEnumerable&lt;IDbDataParameter&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>

### **Callback**

```csharp
public RepositoryRecordCallback Callback { get; }
```

#### Property Value

[RepositoryRecordCallback](./jlw.utilities.data.dbutility.repositoryrecordcallback.md)<br>

### **CommandType**

```csharp
public CommandType CommandType { get; }
```

#### Property Value

CommandType<br>

### **SqlQuery**

```csharp
public string SqlQuery { get; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

## Constructors

### **QueryMethodDefinition(String, RepositoryRecordCallback, Type)**

```csharp
public QueryMethodDefinition(string sql, RepositoryRecordCallback callback, Type returnType)
```

#### Parameters

`sql` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`callback` [RepositoryRecordCallback](./jlw.utilities.data.dbutility.repositoryrecordcallback.md)<br>

`returnType` [Type](https://docs.microsoft.com/en-us/dotnet/api/system.type)<br>

### **QueryMethodDefinition(String, IEnumerable&lt;String&gt;, RepositoryRecordCallback, Type)**

```csharp
public QueryMethodDefinition(string sql, IEnumerable<string> paramList, RepositoryRecordCallback callback, Type returnType)
```

#### Parameters

`sql` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`paramList` [IEnumerable&lt;String&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>

`callback` [RepositoryRecordCallback](./jlw.utilities.data.dbutility.repositoryrecordcallback.md)<br>

`returnType` [Type](https://docs.microsoft.com/en-us/dotnet/api/system.type)<br>

### **QueryMethodDefinition(String, IEnumerable&lt;KeyValuePair&lt;String, Object&gt;&gt;, RepositoryRecordCallback, Type)**

```csharp
public QueryMethodDefinition(string sql, IEnumerable<KeyValuePair<string, object>> paramList, RepositoryRecordCallback callback, Type returnType)
```

#### Parameters

`sql` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`paramList` [IEnumerable&lt;KeyValuePair&lt;String, Object&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>

`callback` [RepositoryRecordCallback](./jlw.utilities.data.dbutility.repositoryrecordcallback.md)<br>

`returnType` [Type](https://docs.microsoft.com/en-us/dotnet/api/system.type)<br>

---

[`< Back`](./)
