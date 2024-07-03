namespace FalconWallet.API.Features.UserWallet.CreateWallet;

public sealed record CreateWalletRequest(Guid UserId,
                                         string? Title,
                                         int CurrencyId);

