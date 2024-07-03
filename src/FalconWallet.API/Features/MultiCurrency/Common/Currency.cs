using FalconWallet.API.Features.UserWallet.Domain;

namespace FalconWallet.API.Features.MultiCurrency.Common;

public class Currency
{
    public int Id { get; private set; }
    public string Code { get; private set; } = null!;
    public string Name { get; private set; } = null!;
    public decimal ConversionRate { get; private set; }
    public DateTime LastModifyOnUtc { get; private set; }
    public ICollection<Wallet>? Wallets { get; private set; }
    public void UpdateConversionRate(decimal conversionRate)
    {
        ConversionRate = conversionRate;
        LastModifyOnUtc = DateTime.UtcNow;
    }

    public static Currency Create(string name,
                                  string code,
                                  Decimal conversionRate)
    {
        Currency currency = new Currency();
        currency.Name = name;
        currency.Code = code;
        currency.ConversionRate = conversionRate;
        currency.LastModifyOnUtc = DateTime.UtcNow;

        return currency;
    }
}
