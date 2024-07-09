namespace FalconWallet.API.Features.MultiCurrency.Common;

public class CurrencyNotFoundException : Exception
{
    public CurrencyNotFoundException(int currencyId) : base($"There is no currency with id: {currencyId}") { }
}
