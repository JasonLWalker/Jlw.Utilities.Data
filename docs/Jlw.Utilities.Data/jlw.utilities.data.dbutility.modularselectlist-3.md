[`< Back`](./)

---

# ModularSelectList&lt;TSelectListItem, TInterface, TModel&gt;

Namespace: Jlw.Utilities.Data.DbUtility

```csharp
public class ModularSelectList<TSelectListItem, TInterface, TModel> : IModularSelectList`3
```

#### Type Parameters

`TSelectListItem`<br>

`TInterface`<br>

`TModel`<br>

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [ModularSelectList&lt;TSelectListItem, TInterface, TModel&gt;](./jlw.utilities.data.dbutility.modularselectlist-3.md)<br>
Implements IModularSelectList&lt;TSelectListItem, TInterface, TModel&gt;

## Properties

### **Items**

```csharp
public IEnumerable<TSelectListItem> Items { get; }
```

#### Property Value

IEnumerable&lt;TSelectListItem&gt;<br>

## Constructors

### **ModularSelectList(IModularDataRepositoryBase&lt;TInterface, TModel&gt;)**

```csharp
public ModularSelectList(IModularDataRepositoryBase<TInterface, TModel> repo)
```

#### Parameters

`repo` IModularDataRepositoryBase&lt;TInterface, TModel&gt;<br>

## Methods

### **Refresh()**

```csharp
public void Refresh()
```

---

[`< Back`](./)
