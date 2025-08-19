[`< Back`](./)

---

# ModularBaseDbUtility

Namespace: Jlw.Utilities.Data.DbUtility

```csharp
public class ModularBaseDbUtility : ModularBaseDbUtility`3, IModularDataRepositoryBase`2, IModularDbUtility
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [ModularDataRepositoryBase&lt;Object, Object&gt;](./jlw.utilities.data.dbutility.modulardatarepositorybase-2.md) → [ModularBaseDbUtility&lt;ModularDbClient&lt;NullDbConnection, NullDbCommand, NullDbParameter&gt;, Object, Object&gt;](./jlw.utilities.data.dbutility.modularbasedbutility-3.md) → [ModularBaseDbUtility](./jlw.utilities.data.dbutility.modularbasedbutility.md)<br>
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

### **ModularBaseDbUtility(String, String)**

```csharp
public ModularBaseDbUtility(string sType, string connString)
```

#### Parameters

`sType` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`connString` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

---

[`< Back`](./)
