namespace FalconWallet.API.Features.UserWallet.Common;

public class InsufficientFundsInWalletException : Exception
{
    public InsufficientFundsInWalletException(Guid walletId) : base($"Wallet with id: {walletId} does not have sufficient funds for operation") { }
}
