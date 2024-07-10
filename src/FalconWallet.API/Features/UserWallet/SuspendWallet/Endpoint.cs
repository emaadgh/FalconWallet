using FalconWallet.API.Features.UserWallet.Common;
using FalconWallet.API.Features.UserWallet.Domain;
using Microsoft.AspNetCore.Mvc;

namespace FalconWallet.API.Features.UserWallet.SuspendWallet;

public static class Endpoint
{
    public static IEndpointRouteBuilder AddSuspendWalletEndPoint(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        endpointRouteBuilder.MapPatch("/wallet/{walletId:guid:required}/suspend", async (
            [FromRoute(Name = "walletId")] Guid walletId,
            WalletService walletService,
            CancellationToken cancellationToken) =>
        {
            await walletService.SuspendWalletAsync(walletId, cancellationToken);

            return Results.Ok("Wallet has been suspended");
        }).WithTags(WalletEndpointSchema.WalletTag);

        return endpointRouteBuilder;
    }
}
