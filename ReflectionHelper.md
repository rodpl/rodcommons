# Introduction #

ReflectionHelper class helps to change content of object instance. Syntax of using this class is kind of DSL.

To instantiate use factory method `For(target)` with "target" as object instance. Then you can point `Field("fieldName")` or `Property("PropertyName")` and `SetValue(value)` or `GetValue()`. Method `Return<T>()` returns "target" as T. I can help you to use it in just one line.

# Samples #

```
public void ChangeTransferAmountToTenDollars(Transfer transfer)
{
	return ReflectionHelper.For(transfer)
		.Field("amount")
		.SetValue(10)
		.Property("Currency")
		.SetValue("USD")
		.Return<Transfer>();
}
```