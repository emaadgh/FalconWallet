using FluentValidation;

namespace FalconWallet.API.Features.Transactions.DepositToWallet;

public class DepositToWalletRequestValidator : AbstractValidator<DepositToWalletRequest>
{
    private const string AmountMessage = "Amount should be greater than zero";
    private const string DescriptionLengthMessage = "Description must not exceed 200 characters";

    public DepositToWalletRequestValidator()
    {
        RuleFor(x => x.WalletId)
               .NotNull();

        RuleFor(x => x.Amount)
            .GreaterThan(decimal.Zero)
            .WithMessage(AmountMessage);

        RuleFor(x => x.Description)
            .MaximumLength(200)
            .WithMessage(DescriptionLengthMessage);
    }
}
