[`< Back`](./)

---

# ModularDbClient&lt;TConnection, TCommand, TParam, TConnBuilder&gt;

Namespace: Jlw.Utilities.Data.DbUtility

```csharp
public class ModularDbClient<TConnection, TCommand, TParam, TConnBuilder> : ModularDbClient`1, IModularDbClient, IModularDbClient`4
```

#### Type Parameters

`TConnection`<br>

`TCommand`<br>

`TParam`<br>

`TConnBuilder`<br>

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → ModularDbClient&lt;TConnection&gt; → [ModularDbClient&lt;TConnection, TCommand, TParam, TConnBuilder&gt;](./jlw.utilities.data.dbutility.modulardbclient-4.md)<br>
Implements [IModularDbClient](./jlw.utilities.data.dbutility.imodulardbclient.md), IModularDbClient&lt;TConnection, TCommand, TParam, TConnBuilder&gt;

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

### **CreateConnectionBuilder(String)**

```csharp
public TConnBuilder CreateConnectionBuilder(string connString)
```

#### Parameters

`connString` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

TConnBuilder<br>

### **CreateConnection()**

```csharp
public TConnection CreateConnection()
```

#### Returns

TConnection<br>

### **CreateConnection(String)**

```csharp
public TConnection CreateConnection(string connString)
```

#### Parameters

`connString` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

TConnection<br>

### **CreateCommand(String)**

```csharp
public TCommand CreateCommand(string cmd)
```

#### Parameters

`cmd` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

TCommand<br>

### **CreateCommand(String, TConnection)**

```csharp
public TCommand CreateCommand(string cmd, TConnection conn)
```

#### Parameters

`cmd` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`conn` TConnection<br>

#### Returns

TCommand<br>

### **AddParameter(TParam, TCommand)**

```csharp
public TParam AddParameter(TParam param, TCommand cmd)
```

#### Parameters

`param` TParam<br>

`cmd` TCommand<br>

#### Returns

TParam<br>

### **CreateNewParameter(TParam, TCommand)**

```csharp
public TParam CreateNewParameter(TParam param, TCommand cmd)
```

#### Parameters

`param` TParam<br>

`cmd` TCommand<br>

#### Returns

TParam<br>

### **CreateNewParameter(IDbDataParameter, IDbCommand)**

```csharp
public IDbDataParameter CreateNewParameter(IDbDataParameter param, IDbCommand cmd)
```

#### Parameters

`param` IDbDataParameter<br>

`cmd` IDbCommand<br>

#### Returns

IDbDataParameter<br>

---

[`< Back`](./)
