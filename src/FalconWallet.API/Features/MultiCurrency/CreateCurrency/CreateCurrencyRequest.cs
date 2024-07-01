namespace FalconWallet.API.Features.MultiCurrency.CreateCurrency;

public sealed record CreateCurrencyRequest(string Code, string Name, decimal ConversionRate);
