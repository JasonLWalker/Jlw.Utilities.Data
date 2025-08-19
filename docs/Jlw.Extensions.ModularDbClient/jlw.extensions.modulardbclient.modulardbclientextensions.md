[`< Back`](./)

---

# ModularDbClientExtensions

Namespace: Jlw.Extensions.ModularDbClient

```csharp
public static class ModularDbClientExtensions
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [ModularDbClientExtensions](./jlw.extensions.modulardbclient.modulardbclientextensions.md)<br>
Attributes [NullableContextAttribute](./system.runtime.compilerservices.nullablecontextattribute.md), [NullableAttribute](./system.runtime.compilerservices.nullableattribute.md), [ExtensionAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.extensionattribute)

## Methods

### **AddModularDbClient&lt;TConnection, TCommand, TParam, TConnBuilder&gt;(IServiceCollection, String, IModularDbClient&lt;TConnection, TCommand, TParam, TConnBuilder&gt;, Int32)**

```csharp
public static IServiceCollection AddModularDbClient<TConnection, TCommand, TParam, TConnBuilder>(IServiceCollection services, string connectionString, IModularDbClient<TConnection, TCommand, TParam, TConnBuilder> dbClient, int commandTimeout)
```

#### Type Parameters

`TConnection`<br>

`TCommand`<br>

`TParam`<br>

`TConnBuilder`<br>

#### Parameters

`services` IServiceCollection<br>

`connectionString` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`dbClient` IModularDbClient&lt;TConnection, TCommand, TParam, TConnBuilder&gt;<br>

`commandTimeout` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

#### Returns

IServiceCollection<br>

### **AddModularDbClient&lt;TConnection, TCommand, TParam&gt;(IServiceCollection, String, IModularDbClient, Int32)**

```csharp
public static IServiceCollection AddModularDbClient<TConnection, TCommand, TParam>(IServiceCollection services, string connectionString, IModularDbClient dbClient, int commandTimeout)
```

#### Type Parameters

`TConnection`<br>

`TCommand`<br>

`TParam`<br>

#### Parameters

`services` IServiceCollection<br>

`connectionString` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`dbClient` IModularDbClient<br>

`commandTimeout` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

#### Returns

IServiceCollection<br>

### **AddModularDbClient&lt;TConnection&gt;(IServiceCollection, String, IModularDbClient, Int32)**

```csharp
public static IServiceCollection AddModularDbClient<TConnection>(IServiceCollection services, string connectionString, IModularDbClient dbClient, int commandTimeout)
```

#### Type Parameters

`TConnection`<br>

#### Parameters

`services` IServiceCollection<br>

`connectionString` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

`dbClient` IModularDbClient<br>

`commandTimeout` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

#### Returns

IServiceCollection<br>

---

[`< Back`](./)
