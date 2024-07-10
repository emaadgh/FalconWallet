using FalconWallet.API.Common;
using FalconWallet.API.Features.MultiCurrency.Common;
using FalconWallet.API.Features.MultiCurrency.CreateCurrency;
using FalconWallet.API.Features.UserWallet.Common;
using FalconWallet.API.Features.UserWallet.Domain;
using Microsoft.AspNetCore.Mvc;

namespace FalconWallet.API.Features.UserWallet.UpdateTitle;

public static class Endpoint
{
    public static IEndpointRouteBuilder AddUpdateTitleEndPoint(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        endpointRouteBuilder.MapPatch("/wallet/{walletId:guid:required}", async (
            [FromBody] UpdateTitleRequest request,
            [FromRoute(Name = "walletId")] Guid walletId,            
            WalletService walletService,
            CancellationToken cancellationToken) =>
        {
            await walletService.UpdateTitleAsync(walletId, request.Title, cancellationToken);

            return Results.Ok("Wallet title updated");
        }).Validator<UpdateTitleRequest>()
          .WithTags("Wallet");

        return endpointRouteBuilder;
    }
}
