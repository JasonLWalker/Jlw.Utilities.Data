[`< Back`](./)

---

# IDataTablesOutput

Namespace: Jlw.Utilities.Data.DataTables

Interface IDataTablesOutput

```csharp
public interface IDataTablesOutput
```

## Properties

### **draw**

```csharp
public abstract int draw { get; set; }
```

#### Property Value

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

### **recordsTotal**

```csharp
public abstract int recordsTotal { get; set; }
```

#### Property Value

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

### **recordsFiltered**

```csharp
public abstract int recordsFiltered { get; set; }
```

#### Property Value

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

### **data**

```csharp
public abstract IEnumerable<object> data { get; set; }
```

#### Property Value

[IEnumerable&lt;Object&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>

### **error**

```csharp
public abstract string error { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **debug**

```csharp
public abstract string debug { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

---

[`< Back`](./)
