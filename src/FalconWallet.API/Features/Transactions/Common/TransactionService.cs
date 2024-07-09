
using FalconWallet.API.Common.Persistence;
using FalconWallet.API.Features.UserWallet.Common;
using System.Threading;

namespace FalconWallet.API.Features.Transactions.Common;

internal class TransactionService(WalletService walletService,
                                  WalletDbContext walletDbContext)
{
    private readonly WalletService _walletService = walletService;
    private readonly WalletDbContext _walletDbContext = walletDbContext;

    public async Task DepositeAsync(Guid walletId, decimal amount, string description, CancellationToken cancellationToken)
    {
        await ValidateTransactionAsync(walletId, amount, cancellationToken);

        var dbTransaction = await _walletDbContext.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            await _walletService.DepositAsync(walletId, amount, cancellationToken);

            Transaction depositTransaction = Transaction.CreateDepositTransaction(walletId,
                                                                                  amount,
                                                                                  description);

            await _walletDbContext.Transactions.AddAsync(depositTransaction,
                                                        cancellationToken);

            await _walletDbContext.SaveChangesAsync(cancellationToken);

            await dbTransaction.CommitAsync(cancellationToken);
        }
        catch (Exception)
        {
            await dbTransaction.RollbackAsync(cancellationToken);
        }
    }

    internal async Task WithdrawAsync(Guid walletId, decimal amount, string description, CancellationToken cancellationToken)
    {
        await ValidateTransactionAsync(walletId, amount, cancellationToken);

        var dbTransaction = await _walletDbContext.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            await _walletService.WithdrawAsync(walletId, amount, cancellationToken);

            Transaction withdrawTransaction = Transaction.CreateWithdrawTransaction(walletId,
                                                                                    amount,
                                                                                    description);

            await _walletDbContext.Transactions.AddAsync(withdrawTransaction,
                                                        cancellationToken);

            await _walletDbContext.SaveChangesAsync(cancellationToken);

            await dbTransaction.CommitAsync(cancellationToken);
        }
        catch (Exception)
        {
            await dbTransaction.RollbackAsync(cancellationToken);
        }
    }

    private async Task ValidateTransactionAsync(Guid walletId, decimal amount, CancellationToken cancellationToken)
    {
        if (!await _walletService.IsWalletAvailable(walletId, cancellationToken))
        {
            throw new WalletNotAvailableException(walletId);
        }

        if (amount == 0)
        {
            throw new InvalidAmountException();
        }
    }

    public async Task<List<Transaction>> GetTransactionsForWalletAsync(Guid walletId,
                                                                                 CancellationToken cancellationToken)
    {
        if (!await _walletService.IsWalletAvailable(walletId, cancellationToken))
        {
            throw new WalletNotAvailableException(walletId);
        }

        return _walletDbContext.Transactions.Where(x => x.WalletId == walletId)
                                           .OrderByDescending(x => x.CreatedOn)
                                           .ToList();
    }
}