namespace FalconWallet.API.Features.Transactions.DepositToWallet;

public sealed record DepositToWalletRequest(Guid WalletId,
                                            decimal Amount,
                                            string? Description);
