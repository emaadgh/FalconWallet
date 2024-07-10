using AutoMapper;
using FalconWallet.API.Common;
using FalconWallet.API.Features.UserWallet.Common;
using Microsoft.AspNetCore.Mvc;

namespace FalconWallet.API.Features.UserWallet.CreateWallet;

public static class Endpoint
{
    public static IEndpointRouteBuilder AddCreateWalletEndPoint(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        endpointRouteBuilder.MapPost("/wallet/", async (
            [FromBody] CreateWalletRequest request,
            WalletService walletService,
            IMapper mapper,
            CancellationToken cancellationToken) =>
        {
            Wallet wallet = await walletService.CreateAsync(request.UserId, request.Title, request.CurrencyId, cancellationToken);

            return mapper.Map<CreateWalletResponse>(wallet);
        }).Validator<CreateWalletRequest>()
          .WithTags(WalletEndpointSchema.WalletTag);

        return endpointRouteBuilder;
    }
}
