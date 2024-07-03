using FalconWallet.API.Features.MultiCurrency.Common;
using Microsoft.AspNetCore.Mvc;

namespace FalconWallet.API.Features.MultiCurrency.CreateCurrency;

public static class Endpoint
{
    public static IEndpointRouteBuilder AddCreateCurrencyEndPoint(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        endpointRouteBuilder.MapPost("/currency", async (
            [FromBody] CreateCurrencyRequest request,
            CurrencyService currencyService,
            CancellationToken cancellationToken) =>
        {
            Currency currency = await currencyService.CreateAsync(request.Name, request.Code, request.ConversionRate, cancellationToken);

            return new CreateCurrencyResponse(currency.Id, currency.Name, currency.Code);
        }).WithTags("Currency");

        return endpointRouteBuilder;
    }
}
