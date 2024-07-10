using FluentValidation;

namespace FalconWallet.API.Features.UserWallet.UpdateTitle;

public class UpdateTitleRequestValidator : AbstractValidator<UpdateTitleRequest>
{
    private const string TitleLengthMessage = "Title must not exceed 30 characters";
    public UpdateTitleRequestValidator()
    {
        RuleFor(x => x.Title)
               .MaximumLength(30)
               .WithMessage(TitleLengthMessage);
    }
}
