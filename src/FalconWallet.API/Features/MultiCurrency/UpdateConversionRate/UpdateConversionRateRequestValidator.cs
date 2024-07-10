using FluentValidation;

namespace FalconWallet.API.Features.MultiCurrency.UpdateConversionRate;

public class UpdateConversionRateRequestValidator : AbstractValidator<UpdateConversionRateRequest>
{
    private const string ConversionRateMessage = "Conversion Rate should be greater than zero";
    public UpdateConversionRateRequestValidator()
    {
        RuleFor(x => x.ConversionRate)
               .GreaterThan(decimal.Zero)
               .WithMessage(ConversionRateMessage);
    }
}
