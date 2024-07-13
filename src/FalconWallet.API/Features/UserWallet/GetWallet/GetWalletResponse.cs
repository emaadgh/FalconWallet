namespace FalconWallet.API.Features.UserWallet.GetWallet;

public sealed record GetWalletResponse(string Title, string Currency, decimal Balance);
