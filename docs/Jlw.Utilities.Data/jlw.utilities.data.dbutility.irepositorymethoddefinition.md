[`< Back`](./)

---

# IRepositoryMethodDefinition

Namespace: Jlw.Utilities.Data.DbUtility

Interface IRepositoryMethodDefinition

```csharp
public interface IRepositoryMethodDefinition
```

## Properties

### **Parameters**

```csharp
public abstract IEnumerable<IDbDataParameter> Parameters { get; }
```

#### Property Value

[IEnumerable&lt;IDbDataParameter&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>

### **Callback**

```csharp
public abstract RepositoryRecordCallback Callback { get; }
```

#### Property Value

[RepositoryRecordCallback](./jlw.utilities.data.dbutility.repositoryrecordcallback.md)<br>

### **CommandType**

```csharp
public abstract CommandType CommandType { get; }
```

#### Property Value

CommandType<br>

### **SqlQuery**

```csharp
public abstract string SqlQuery { get; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

---

[`< Back`](./)
