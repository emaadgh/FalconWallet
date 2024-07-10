using FalconWallet.API.Common;
using FalconWallet.API.Features.Transactions.Common;
using FalconWallet.API.Features.UserWallet.Common;
using Microsoft.AspNetCore.Mvc;

namespace FalconWallet.API.Features.Transactions.DepositToWallet;

public static class Endpoint
{
    public static IEndpointRouteBuilder AddDepositToWalletEndPoint(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        endpointRouteBuilder.MapPost("/transaction/deposit", async (
            [FromBody] DepositToWalletRequest request,
            TransactionService transactionService,
            CancellationToken cancellationToken) =>
        {
            await transactionService.DepositeAsync(request.WalletId,
                                                   request.Amount,
                                                   request.Description,
                                                   cancellationToken);

            return Results.Ok("Deposit added to the wallet");
        }).Validator<DepositToWalletRequest>()
          .WithTags(TransactionEndpointSchema.TransactionTag);

        return endpointRouteBuilder;
    }
}
