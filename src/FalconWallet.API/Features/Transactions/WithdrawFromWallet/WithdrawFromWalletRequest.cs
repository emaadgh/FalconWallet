namespace FalconWallet.API.Features.Transactions.WithdrawFromWallet;

public sealed record WithdrawFromWalletRequest(Guid WalletId,
                                               decimal Amount,
                                               string? Description);
