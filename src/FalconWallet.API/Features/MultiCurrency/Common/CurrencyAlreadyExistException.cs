namespace FalconWallet.API.Features.MultiCurrency.Common;

public class CurrencyAlreadyExistException : Exception
{
    public CurrencyAlreadyExistException(string code) : base($"Currency with code {code} Already Exist") { }
}
