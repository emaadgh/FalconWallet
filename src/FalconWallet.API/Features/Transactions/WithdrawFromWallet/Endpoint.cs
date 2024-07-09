using FalconWallet.API.Features.Transactions.Common;
using FalconWallet.API.Features.Transactions.DepositToWallet;
using Microsoft.AspNetCore.Mvc;

namespace FalconWallet.API.Features.Transactions.WithdrawFromWallet;

public static class Endpoint
{
    public static IEndpointRouteBuilder AddWithdrawFromWalletEndPoint(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        endpointRouteBuilder.MapPost("/transaction/withdraw", async (
            [FromBody] WithdrawFromWalletRequest request,
            TransactionService transactionService,
            CancellationToken cancellationToken) =>
        {
            await transactionService.WithdrawAsync(request.WalletId,
                                                   request.Amount,
                                                   request.Description,
                                                   cancellationToken);

            return Results.Ok("Withdraw amount removed from the wallet");
        }).WithTags("Transaction");

        return endpointRouteBuilder;
    }
}
