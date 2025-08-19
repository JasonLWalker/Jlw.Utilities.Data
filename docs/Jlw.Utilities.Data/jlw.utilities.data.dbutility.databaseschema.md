[`< Back`](./)

---

# DatabaseSchema

Namespace: Jlw.Utilities.Data.DbUtility

```csharp
public class DatabaseSchema : IDatabaseSchema
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [DatabaseSchema](./jlw.utilities.data.dbutility.databaseschema.md)<br>
Implements [IDatabaseSchema](./jlw.utilities.data.dbutility.idatabaseschema.md)

## Properties

### **Name**

```csharp
public string Name { get; protected set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **DefaultCollation**

```csharp
public string DefaultCollation { get; protected set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **CreationDate**

```csharp
public DateTime CreationDate { get; protected set; }
```

#### Property Value

[DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime)<br>

## Constructors

### **DatabaseSchema()**

```csharp
public DatabaseSchema()
```

### **DatabaseSchema(IDataRecord)**

```csharp
public DatabaseSchema(IDataRecord o)
```

#### Parameters

`o` IDataRecord<br>

---

[`< Back`](./)
