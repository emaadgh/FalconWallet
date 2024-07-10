using FluentValidation;

namespace FalconWallet.API.Features.UserWallet.CreateWallet;

public class CreateWalletRequestValidator : AbstractValidator<CreateWalletRequest>
{
    private const string TitleLengthMessage = "Title must not exceed 30 characters";

    public CreateWalletRequestValidator()
    {
        RuleFor(x => x.UserId)
               .NotNull();

        RuleFor(x => x.Title)
               .MaximumLength(30)
               .WithMessage(TitleLengthMessage);

        RuleFor(x => x.CurrencyId)
                .NotNull();
    }
}
