namespace FalconWallet.API.Features.UserWallet.Common;

public class WalletForUserAlreadyExistException : Exception
{
    public WalletForUserAlreadyExistException(int currencyId, Guid UserId) : base($"User with id: {UserId} already has a wallet for currency id: {currencyId}") { }
}
