using AutoMapper;
using FalconWallet.API.Features.Transactions.Common;
using FalconWallet.API.Features.Transactions.DepositToWallet;
using Microsoft.AspNetCore.Mvc;

namespace FalconWallet.API.Features.Transactions.WalletHistory;

public static class Endpoint
{
    public static IEndpointRouteBuilder AddWalletHistoryEndPoint(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        endpointRouteBuilder.MapGet("/transaction/{walletId:guid:required}", async (
            [FromRoute(Name = "walletId")] Guid walletId,
            TransactionService transactionService,
            IMapper mapper,
            CancellationToken cancellationToken) =>
        {
            List<Transaction> transactions = await transactionService.GetTransactionsForWalletAsync(walletId, cancellationToken);

            var transactionsDtoList = mapper.Map<List<TransactionDto>>(transactions);

            return Results.Ok(transactionsDtoList);
        }).WithTags(TransactionEndpointSchema.TransactionTag);

        return endpointRouteBuilder;
    }
}
