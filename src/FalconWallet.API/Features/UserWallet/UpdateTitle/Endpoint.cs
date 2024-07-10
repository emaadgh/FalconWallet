using FalconWallet.API.Common;
using FalconWallet.API.Features.UserWallet.Common;
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
          .WithTags(WalletEndpointSchema.WalletTag);

        return endpointRouteBuilder;
    }
}
