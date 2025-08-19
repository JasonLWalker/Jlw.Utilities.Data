[`< Back`](./)

---

# DataTablesOutput

Namespace: Jlw.Utilities.Data.DataTables

```csharp
public class DataTablesOutput : IDataTablesOutput
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [DataTablesOutput](./jlw.utilities.data.datatables.datatablesoutput.md)<br>
Implements [IDataTablesOutput](./jlw.utilities.data.datatables.idatatablesoutput.md)

## Properties

### **draw**

```csharp
public int draw { get; set; }
```

#### Property Value

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

### **recordsTotal**

```csharp
public int recordsTotal { get; set; }
```

#### Property Value

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

### **recordsFiltered**

```csharp
public int recordsFiltered { get; set; }
```

#### Property Value

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

### **data**

```csharp
public IEnumerable<object> data { get; set; }
```

#### Property Value

[IEnumerable&lt;Object&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1)<br>

### **error**

```csharp
public string error { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **debug**

```csharp
public string debug { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

## Constructors

### **DataTablesOutput()**

```csharp
public DataTablesOutput()
```

### **DataTablesOutput(IDataTablesInput)**

```csharp
public DataTablesOutput(IDataTablesInput input)
```

#### Parameters

`input` [IDataTablesInput](./jlw.utilities.data.datatables.idatatablesinput.md)<br>

---

[`< Back`](./)
