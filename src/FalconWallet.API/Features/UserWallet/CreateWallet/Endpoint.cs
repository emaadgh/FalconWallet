using FalconWallet.API.Common;
using FalconWallet.API.Features.UserWallet.Common;
using FalconWallet.API.Features.UserWallet.Domain;
using Microsoft.AspNetCore.Mvc;

namespace FalconWallet.API.Features.UserWallet.CreateWallet;

public static class Endpoint
{
    public static IEndpointRouteBuilder AddCreateWalletEndPoint(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        endpointRouteBuilder.MapPost("/wallet/", async (
            [FromBody] CreateWalletRequest request,
            WalletService walletService,
            CancellationToken cancellationToken) =>
        {
            Wallet wallet = await walletService.CreateAsync(request.UserId, request.Title, request.CurrencyId, cancellationToken);

            return new CreateWalletResponse(wallet.Id);
        }).Validator<CreateWalletRequest>()
          .WithTags(WalletEndpointSchema.WalletTag);

        return endpointRouteBuilder;
    }
}
