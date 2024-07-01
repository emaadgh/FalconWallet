using FalconWallet.API.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FalconWallet.API.Features.MultiCurrency.Common;

public class CurrencyService(WalletDbContext walletDbContext)
{
    public async Task<Currency> CreateAsync(string code,
                                            string name,
                                            decimal conversionRate,
                                            CancellationToken cancellationToken = default)
    {
        if (await walletDbContext.Currencies.AnyAsync(x => x.Code.Equals(code), cancellationToken))
        {
            throw new Exception("Already exists");
        }

        if (conversionRate == 0)
        {
            throw new Exception("Invalid Conversion Rate");
        }

        var newCurrency = new Currency
        {
            Name = name,
            Code = code,
            ConversionRate = conversionRate
        };

        await walletDbContext.Currencies.AddAsync(newCurrency, cancellationToken);
        await walletDbContext.SaveChangesAsync(cancellationToken);

        return newCurrency;
    }

    public async Task UpdateConversionRateAsync(int currencyId,
                                                decimal conversionRate,
                                                CancellationToken cancellationToken = default)
    {
        if (conversionRate == 0)
        {
            throw new Exception("Invalid Conversion Rate");
        }

        Currency? currency = await walletDbContext.Currencies.FirstOrDefaultAsync(x => x.Id.Equals(currencyId), cancellationToken);

        if (currency is null)
        {
            throw new Exception("Not found");
        }

        currency.UpdateConversionRate(conversionRate);
        await walletDbContext.SaveChangesAsync(cancellationToken);
    }
}
