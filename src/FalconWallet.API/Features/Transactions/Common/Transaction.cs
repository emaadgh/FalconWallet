using FalconWallet.API.Features.UserWallet.Common;

namespace FalconWallet.API.Features.Transactions.Common;

public class Transaction
{
    public Guid Id { get; private set; }
    public Guid WalletId { get; private set; }
    public Wallet Wallet { get; private set; } = null!;
    public string? Description { get; private set; }
    public decimal Amount { get; private set; }
    public TransactionType Type { get; private set; }
    public DateTime CreatedOn { get; private set; }

    public static Transaction CreateDepositTransaction(Guid walletId,
                                                       decimal amount,
                                                       string? description)
    {
        Transaction transaction = new Transaction();
        transaction.WalletId = walletId;
        transaction.Description = description;
        transaction.Amount = amount;
        transaction.Type = TransactionType.Deposit;
        transaction.CreatedOn = DateTime.UtcNow;

        return transaction;
    }

    public static Transaction CreateWithdrawTransaction(Guid walletId,
                                                         decimal amount,
                                                         string? description)
    {
        Transaction transaction = new Transaction();
        transaction.WalletId = walletId;
        transaction.Description = description;
        transaction.Amount = amount;
        transaction.Type = TransactionType.Withdraw;
        transaction.CreatedOn = DateTime.UtcNow;

        return transaction;
    }
}
