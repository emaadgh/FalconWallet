
using FalconWallet.API.Common.Persistence;
using FalconWallet.API.Features.UserWallet.Common;
using System.Threading;

namespace FalconWallet.API.Features.Transactions.Common;

internal class TransactionService(WalletService walletService,
                                  WalletDbContext walletDbContext)
{
    public async Task DepositeAsync(Guid walletId, decimal amount, string description, CancellationToken cancellationToken)
    {
        if (!await walletService.IsWalletAvailable(walletId, cancellationToken))
        {
            throw new Exception($"Wallet with id {walletId} is not available");
        }

        if (amount == 0)
        {
            throw new Exception("amount can't be zero");
        }

        var dbTransaction = await walletDbContext.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            await walletService.DepositAsync(walletId, amount, cancellationToken);

            Transaction depositTransaction = Transaction.CreateDepositTransaction(walletId,
                                                                                  amount,
                                                                                  description);

            await walletDbContext.Transactions.AddAsync(depositTransaction,
                                                        cancellationToken);

            await walletDbContext.SaveChangesAsync(cancellationToken);

            await dbTransaction.CommitAsync(cancellationToken);
        }
        catch (Exception)
        {
            await dbTransaction.RollbackAsync(cancellationToken);
        }
    }

    internal async Task WithdrawAsync(Guid walletId, decimal amount, string description, CancellationToken cancellationToken)
    {
        if (!await walletService.IsWalletAvailable(walletId, cancellationToken))
        {
            throw new Exception($"Wallet with id {walletId} is not available");
        }

        if (amount == 0)
        {
            throw new Exception("amount can't be zero");
        }

        var dbTransaction = await walletDbContext.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            await walletService.WithdrawAsync(walletId, amount, cancellationToken);

            Transaction withdrawTransaction = Transaction.CreateWithdrawTransaction(walletId,
                                                                                    amount,
                                                                                    description);

            await walletDbContext.Transactions.AddAsync(withdrawTransaction,
                                                        cancellationToken);

            await walletDbContext.SaveChangesAsync(cancellationToken);

            await dbTransaction.CommitAsync(cancellationToken);
        }
        catch (Exception)
        {
            await dbTransaction.RollbackAsync(cancellationToken);
        }
    }

    public async Task<List<Transaction>> GetTransactionsForWalletAsync(Guid walletId,
                                                                                 CancellationToken cancellationToken)
    {
        if (!await walletService.IsWalletAvailable(walletId, cancellationToken))
        {
            throw new Exception($"Wallet with id {walletId} is not available");
        }

        return walletDbContext.Transactions.Where(x => x.WalletId == walletId)
                                           .OrderByDescending(x => x.CreatedOn)
                                           .ToList();
    }
}