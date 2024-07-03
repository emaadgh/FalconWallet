using FalconWallet.API.Features.UserWallet.Domain;

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
}
