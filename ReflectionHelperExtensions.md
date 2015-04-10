# Introduction #

Simple extensions which adds `Reflect()` to any object which returns ReflectionHelper instance.

# Samples #

```
public void ChangeTransferAmountToTenDollars(Transfer transfer)
{
	return transfer.Reflect()
		.Field("amount")
		.SetValue(10)
		.Property("Currency")
		.SetValue("USD")
		.Return<Transfer>();
}
```