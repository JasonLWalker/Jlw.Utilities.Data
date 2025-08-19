[`< Back`](./)

---

# IModularDbClient&lt;TConnection, TCommand, TParameter, TConnectionStringBuilder&gt;

Namespace: Jlw.Utilities.Data.DbUtility

```csharp
public interface IModularDbClient<TConnection, TCommand, TParameter, TConnectionStringBuilder> : IModularDbClient
```

#### Type Parameters

`TConnection`<br>

`TCommand`<br>

`TParameter`<br>

`TConnectionStringBuilder`<br>

Implements [IModularDbClient](./jlw.utilities.data.dbutility.imodulardbclient.md)

## Methods

### **CreateConnectionBuilder(String)**

```csharp
TConnectionStringBuilder CreateConnectionBuilder(string connString)
```

#### Parameters

`connString` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

TConnectionStringBuilder<br>

### **CreateConnection()**

```csharp
TConnection CreateConnection()
```

#### Returns

TConnection<br>

### **CreateConnection(String)**

```csharp
TConnection CreateConnection(string connString)
```

#### Parameters

`connString` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

TConnection<br>

### **CreateCommand(String, TConnection)**

```csharp
TCommand CreateCommand(string cmd, TConnection conn)
```

#### Parameters

`cmd` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`conn` TConnection<br>

#### Returns

TCommand<br>

### **CreateNewParameter(TParameter, TCommand)**

```csharp
TParameter CreateNewParameter(TParameter param, TCommand cmd)
```

#### Parameters

`param` TParameter<br>

`cmd` TCommand<br>

#### Returns

TParameter<br>

### **CreateNewParameter(IDbDataParameter, IDbCommand)**

```csharp
IDbDataParameter CreateNewParameter(IDbDataParameter param, IDbCommand cmd)
```

#### Parameters

`param` IDbDataParameter<br>

`cmd` IDbCommand<br>

#### Returns

IDbDataParameter<br>

### **AddParameter(TParameter, TCommand)**

```csharp
TParameter AddParameter(TParameter param, TCommand cmd)
```

#### Parameters

`param` TParameter<br>

`cmd` TCommand<br>

#### Returns

TParameter<br>

---

[`< Back`](./)
