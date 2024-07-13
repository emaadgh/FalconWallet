using AutoMapper;
using FalconWallet.API.Features.UserWallet.Common;
using Microsoft.AspNetCore.Mvc;

namespace FalconWallet.API.Features.UserWallet.GetWallet;

public static class Endpoint
{
    public static IEndpointRouteBuilder AddGetWalletEndPoint(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        endpointRouteBuilder.MapGet("/wallet/{walletId:guid:required}", async (
            [FromRoute(Name = "walletId")] Guid walletId,
            WalletService walletService,
            IMapper mapper,
            CancellationToken cancellationToken) =>
        {
            Wallet wallet = await walletService.GetWalletAsync(walletId, cancellationToken);

            var walletResponse = mapper.Map<GetWalletResponse>(wallet);

            return Results.Ok(walletResponse);
        }).WithTags(WalletEndpointSchema.WalletTag);

        return endpointRouteBuilder;
    }
}