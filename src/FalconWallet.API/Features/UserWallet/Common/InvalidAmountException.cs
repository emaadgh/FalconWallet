namespace FalconWallet.API.Features.UserWallet.Common;

public class InvalidAmountException : Exception
{
    private const string _message = "Amount cannot be zero";
    public InvalidAmountException() : base(_message) { }
}
