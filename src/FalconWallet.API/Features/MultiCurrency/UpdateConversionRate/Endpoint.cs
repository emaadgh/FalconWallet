using FalconWallet.API.Common;
using FalconWallet.API.Features.MultiCurrency.Common;
using Microsoft.AspNetCore.Mvc;

namespace FalconWallet.API.Features.MultiCurrency.UpdateConversionRate;

public static class Endpoint
{
    public static IEndpointRouteBuilder AddUpdateConversionRateEndPoint(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        endpointRouteBuilder.MapPatch("/currency/{currencyId:required}", async (
            [FromBody] UpdateConversionRateRequest request,
            [FromRoute(Name = "currencyId")] int id,
            CurrencyService currencyService,
            CancellationToken cancellationToken) =>
        {
            await currencyService.UpdateConversionRateAsync(id, request.ConversionRate, cancellationToken);

            return Results.Ok("Currency conversion rate updated");
        }).Validator<UpdateConversionRateRequest>()
          .WithTags(CurrencyEndpointSchema.CurrencyTag);

        return endpointRouteBuilder;
    }
}
