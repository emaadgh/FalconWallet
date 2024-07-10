using FluentValidation;

namespace FalconWallet.API.Features.MultiCurrency.CreateCurrency;
public class CreateCurrencyRequestValidator : AbstractValidator<CreateCurrencyRequest>
{
    private const string CodeRequiredMessage = "A valid Code is required";
    private const string NameRequiredMessage = "A valid Name is required";

    private const string CodeLengthMessage = "Code must not exceed 10 characters";
    private const string NameLengthMessage = "Code must not exceed 25 characters";

    private const string ConversionRateMessage = "Conversion Rate should be greater than zero";

    public CreateCurrencyRequestValidator()
    {
        RuleFor(x => x.Code)
            .NotNull().WithMessage(CodeRequiredMessage)
            .NotEmpty().WithMessage(CodeRequiredMessage)
            .MaximumLength(10).WithMessage(CodeLengthMessage);

        RuleFor(x => x.Name)
            .NotNull().WithMessage(NameRequiredMessage)
            .NotEmpty().WithMessage(NameRequiredMessage)
            .MaximumLength(25).WithMessage(NameLengthMessage);

        RuleFor(x => x.ConversionRate)
            .GreaterThan(decimal.Zero).WithMessage(ConversionRateMessage);
    }
}