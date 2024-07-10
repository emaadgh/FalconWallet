using FalconWallet.API.Common.Persistence;
using FalconWallet.API.Features.MultiCurrency.Common;
using FalconWallet.API.Features.UserWallet.Common;
using Microsoft.EntityFrameworkCore;

namespace FalconWallet.API.Features.UserWallet.Common;

public class WalletService(CurrencyService currencyService,
                           WalletDbContext walletDbContext)
{
    private readonly CurrencyService _currencyService = currencyService;
    private readonly WalletDbContext _walletDbContext = walletDbContext;

    public async Task<Wallet> CreateAsync(Guid userId,
                                          string? title,
                                          int currencyId,
                                          CancellationToken cancellationToken)
    {
        if (!await _currencyService.HasByIdAsync(currencyId, cancellationToken))
        {
            throw new CurrencyNotFoundException(currencyId);
        }

        if (await _walletDbContext.Wallets.AnyAsync(x => x.UserId == userId && x.CurrencyId == currencyId))
        {
            throw new WalletForUserAlreadyExistException(currencyId, userId);
        }

        Wallet wallet = Wallet.Create(userId, title, currencyId);

        await _walletDbContext.Wallets.AddAsync(wallet, cancellationToken);
        await _walletDbContext.SaveChangesAsync(cancellationToken);

        return wallet;
    }

    public async Task UpdateTitleAsync(Guid walletId, string? title, CancellationToken cancellationToken = default)
    {
        Wallet wallet = await GetWalletFromDbAsync(walletId, cancellationToken);

        wallet.UpdateTitle(title);
        await _walletDbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task SuspendWalletAsync(Guid walletId, CancellationToken cancellationToken)
    {
        Wallet wallet = await GetWalletFromDbAsync(walletId, cancellationToken);

        wallet.SuspendWallet();
        await _walletDbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> IsWalletAvailable(Guid walletId, CancellationToken cancellationToken)
    {
        Wallet? wallet = await GetWalletFromDbAsync(walletId, cancellationToken);

        return wallet.Status == WalletStatus.Active;
    }

    internal async Task DepositAsync(Guid walletId, decimal amount, CancellationToken cancellationToken)
    {
        Wallet? wallet = await GetWalletFromDbAsync(walletId, cancellationToken);

        wallet.IncreaseBalance(amount);

        await _walletDbContext.SaveChangesAsync(cancellationToken);
    }

    internal async Task WithdrawAsync(Guid walletId, decimal amount, CancellationToken cancellationToken)
    {
        Wallet? wallet = await GetWalletFromDbAsync(walletId, cancellationToken);

        if (wallet.Balance - amount < 0)
        {
            throw new InsufficientFundsInWalletException(walletId);
        }

        wallet.DecreaseBalance(amount);

        await _walletDbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task<Wallet> GetWalletFromDbAsync(Guid walletId, CancellationToken cancellationToken)
    {
        Wallet? wallet = await _walletDbContext.Wallets.FirstOrDefaultAsync(x => x.Id == walletId, cancellationToken);
        if (wallet == null)
        {
            throw new WalletNotFoundException(walletId);
        }

        return wallet;
    }
}