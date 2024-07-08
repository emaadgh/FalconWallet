using FalconWallet.API.Common.Persistence;
using FalconWallet.API.Features.MultiCurrency.Common;
using FalconWallet.API.Features.UserWallet.Domain;
using Microsoft.EntityFrameworkCore;

namespace FalconWallet.API.Features.UserWallet.Common;

public class WalletService(CurrencyService currencyService,
                           WalletDbContext walletDbContext)
{
    public async Task<Wallet> CreateAsync(Guid userId,
                                          string? title,
                                          int currencyId,
                                          CancellationToken cancellationToken)
    {
        if (!await currencyService.HasByIdAsync(currencyId, cancellationToken))
        {
            throw new Exception($"Currency {currencyId} not found!");
        }

        if (await walletDbContext.Wallets.AnyAsync(x => x.UserId == userId && x.CurrencyId == currencyId))
        {
            throw new Exception($"Wallet {currencyId} for {userId} already exists!");
        }

        Wallet wallet = Wallet.Create(userId, title, currencyId);

        await walletDbContext.Wallets.AddAsync(wallet, cancellationToken);
        await walletDbContext.SaveChangesAsync(cancellationToken);

        return wallet;
    }

    public async Task UpdateTitleAsync(Guid walletId, string? title, CancellationToken cancellationToken = default)
    {
        Wallet wallet = await GetWalletFromDbAsync(walletId, cancellationToken);

        wallet.UpdateTitle(title);
        await walletDbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task SuspendWalletAsync(Guid walletId, CancellationToken cancellationToken)
    {
        Wallet wallet = await GetWalletFromDbAsync(walletId, cancellationToken);

        wallet.SuspendWallet();
        await walletDbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> IsWalletAvailable(Guid walletId, CancellationToken cancellationToken)
    {
        Wallet? wallet = await GetWalletFromDbAsync(walletId, cancellationToken);

        return wallet.Status == WalletStatus.Active;
    }

    internal async Task Deposit(Guid walletId, decimal amount, CancellationToken cancellationToken)
    {
        Wallet? wallet = await GetWalletFromDbAsync(walletId, cancellationToken);

        wallet.IncreaseBalance(amount);

        await walletDbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task<Wallet> GetWalletFromDbAsync(Guid walletId, CancellationToken cancellationToken)
    {
        Wallet? wallet = await walletDbContext.Wallets.FirstOrDefaultAsync(x => x.Id == walletId, cancellationToken);
        if (wallet == null)
        {
            throw new Exception($"Wallet with {walletId} not found");
        }

        return wallet;
    }
}