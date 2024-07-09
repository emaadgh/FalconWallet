namespace FalconWallet.API.Features.UserWallet.Common;

public class WalletNotFoundException : Exception
{
    public WalletNotFoundException(Guid walletId) : base($"Wallet with id: {walletId} does not exist") { }
}
