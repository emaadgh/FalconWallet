namespace FalconWallet.API.Features.MultiCurrency.Common;

public class InvalidConversionRateException : Exception
{
    private const string _message = "Conversion Rate value must be more than zero";
    public InvalidConversionRateException() : base(_message) { }
}
