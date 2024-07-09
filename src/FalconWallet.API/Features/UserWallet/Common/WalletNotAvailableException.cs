namespace FalconWallet.API.Features.UserWallet.Common;

public class WalletNotAvailableException : Exception
{
    public WalletNotAvailableException(Guid walletId)
        : base($"Wallet with id {walletId} is not available")
    {
    }
}
