using FalconWallet.API.Features.MultiCurrency.Common;
using Microsoft.AspNetCore.Mvc;

namespace FalconWallet.API.Features.MultiCurrency.UpdateConversionRate;

public static class Endpoint
{
    public static IEndpointRouteBuilder AddUpdateConversionRateEndPoint(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        endpointRouteBuilder.MapPatch("/currency/{currencyId:required}", async (
            [FromRoute(Name = "currencyId")] int id,
            [FromBody] UpdateConversionRateRequest request,
            CurrencyService currencyService,
            CancellationToken cancellationToken) =>
        {
            await currencyService.UpdateConversionRateAsync(id, request.ConversionRate, cancellationToken);

            return Results.Ok("Currency conversion rate updated");
        }).WithTags("Currency");

        return endpointRouteBuilder;
    }
}
