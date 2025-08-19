[`< Back`](./)

---

# MockDataParameterCollection

Namespace: Jlw.Utilities.Data.DbUtility

```csharp
public class MockDataParameterCollection : System.Data.Common.DbParameterCollection, System.Data.IDataParameterCollection, System.Collections.IList, System.Collections.ICollection, System.Collections.IEnumerable
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [MarshalByRefObject](https://docs.microsoft.com/en-us/dotnet/api/system.marshalbyrefobject) → DbParameterCollection → [MockDataParameterCollection](./jlw.utilities.data.dbutility.mockdataparametercollection.md)<br>
Implements IDataParameterCollection, [IList](https://docs.microsoft.com/en-us/dotnet/api/system.collections.ilist), [ICollection](https://docs.microsoft.com/en-us/dotnet/api/system.collections.icollection), [IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.ienumerable)<br>
Attributes [DefaultMemberAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.reflection.defaultmemberattribute)

## Properties

### **Count**

```csharp
public int Count { get; }
```

#### Property Value

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

### **SyncRoot**

```csharp
public object SyncRoot { get; }
```

#### Property Value

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

### **IsFixedSize**

```csharp
public bool IsFixedSize { get; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **IsReadOnly**

```csharp
public bool IsReadOnly { get; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **IsSynchronized**

```csharp
public bool IsSynchronized { get; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **Item**

```csharp
public DbParameter Item { get; set; }
```

#### Property Value

DbParameter<br>

### **Item**

```csharp
public DbParameter Item { get; set; }
```

#### Property Value

DbParameter<br>

## Constructors

### **MockDataParameterCollection()**

```csharp
public MockDataParameterCollection()
```

## Methods

### **Add(Object)**

```csharp
public int Add(object value)
```

#### Parameters

`value` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

#### Returns

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

### **Clear()**

```csharp
public void Clear()
```

### **Contains(Object)**

```csharp
public bool Contains(object value)
```

#### Parameters

`value` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **IndexOf(Object)**

```csharp
public int IndexOf(object value)
```

#### Parameters

`value` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

#### Returns

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

### **Insert(Int32, Object)**

```csharp
public void Insert(int index, object value)
```

#### Parameters

`index` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

`value` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

### **Remove(Object)**

```csharp
public void Remove(object value)
```

#### Parameters

`value` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

### **RemoveAt(Int32)**

```csharp
public void RemoveAt(int index)
```

#### Parameters

`index` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

### **RemoveAt(String)**

```csharp
public void RemoveAt(string parameterName)
```

#### Parameters

`parameterName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **IndexOf(String)**

```csharp
public int IndexOf(string parameterName)
```

#### Parameters

`parameterName` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

### **Contains(String)**

```csharp
public bool Contains(string value)
```

#### Parameters

`value` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **CopyTo(Array, Int32)**

```csharp
public void CopyTo(Array array, int index)
```

#### Parameters

`array` [Array](https://docs.microsoft.com/en-us/dotnet/api/system.array)<br>

`index` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

### **GetEnumerator()**

```csharp
public IEnumerator GetEnumerator()
```

#### Returns

[IEnumerator](https://docs.microsoft.com/en-us/dotnet/api/system.collections.ienumerator)<br>

### **AddRange(Array)**

```csharp
public void AddRange(Array values)
```

#### Parameters

`values` [Array](https://docs.microsoft.com/en-us/dotnet/api/system.array)<br>

---

[`< Back`](./)
