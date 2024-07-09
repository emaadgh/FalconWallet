using FalconWallet.API.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FalconWallet.API.Features.MultiCurrency.Common;

public class CurrencyService(WalletDbContext walletDbContext)
{
    private readonly WalletDbContext _walletDbContext = walletDbContext;

    public async Task<Currency> CreateAsync(string code,
                                            string name,
                                            decimal conversionRate,
                                            CancellationToken cancellationToken = default)
    {
        if (await _walletDbContext.Currencies.AnyAsync(x => x.Code.Equals(code), cancellationToken))
        {
            throw new CurrencyAlreadyExistException(code);
        }

        if (conversionRate == 0)
        {
            throw new InvalidConversionRateException();
        }

        var newCurrency = Currency.Create(name, code, conversionRate);

        await _walletDbContext.Currencies.AddAsync(newCurrency, cancellationToken);
        await _walletDbContext.SaveChangesAsync(cancellationToken);

        return newCurrency;
    }

    public async Task UpdateConversionRateAsync(int currencyId,
                                                decimal conversionRate,
                                                CancellationToken cancellationToken = default)
    {
        if (conversionRate == 0)
        {
            throw new InvalidConversionRateException();
        }

        Currency? currency = await _walletDbContext.Currencies.FirstOrDefaultAsync(x => x.Id.Equals(currencyId), cancellationToken);

        if (currency is null)
        {
            throw new CurrencyNotFoundException(currencyId);
        }

        currency.UpdateConversionRate(conversionRate);
        await _walletDbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> HasByIdAsync(int currencyId, CancellationToken cancellationToken = default)
    {
        return await _walletDbContext.Currencies.AnyAsync(x => x.Id == currencyId, cancellationToken);
    }
}
