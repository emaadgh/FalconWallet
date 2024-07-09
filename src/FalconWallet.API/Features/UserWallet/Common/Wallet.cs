using FalconWallet.API.Features.MultiCurrency.Common;
using FalconWallet.API.Features.Transactions.Common;
using FalconWallet.API.Features.UserWallet.Common;

namespace FalconWallet.API.Features.UserWallet.Domain;

public class Wallet
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public string? Title { get; private set; }
    public decimal Balance { get; private set; }
    public DateTime CreatedOn { get; private set; }
    public int CurrencyId { get; private set; }
    public Currency Currency { get; private set; } = null!;
    public WalletStatus Status { get; private set; }
    public ICollection<Transaction>? Transactions { get; private set; }
    public static Wallet Create(Guid userId,
                                string? title,
                                int currencyId)
    {
        Wallet wallet = new Wallet();
        wallet.UserId = userId;
        wallet.Title = title;
        wallet.Balance = 0;
        wallet.CurrencyId = currencyId;
        wallet.CreatedOn = DateTime.UtcNow;
        wallet.Status = WalletStatus.Active;

        return wallet;
    }

    public void UpdateTitle(string? title)
    {
        Title = title;
    }

    public void SuspendWallet()
    {
        Status = WalletStatus.Suspend;
    }

    public void IncreaseBalance(decimal amount)
    {
        Balance += amount;
    }

    public void DecreaseBalance(decimal amount)
    {
        Balance -= amount;
    }
}
