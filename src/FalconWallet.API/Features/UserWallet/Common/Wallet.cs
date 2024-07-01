using FalconWallet.API.Features.MultiCurrency.Common;

namespace FalconWallet.API.Features.UserWallet.Domain;

public class Wallet
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string? Title { get; set; }
    public decimal Balance { get; set; }
    public DateTime CreatedOn { get; set; }
    public int CurrencyId { get; set; }
    public Currency Currency { get; set; } = null!;
}
