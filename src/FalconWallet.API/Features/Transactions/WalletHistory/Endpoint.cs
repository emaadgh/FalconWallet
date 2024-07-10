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
            CancellationToken cancellationToken) =>
        {
            List<Transaction> transactions = await transactionService.GetTransactionsForWalletAsync(walletId, cancellationToken);

            List<TransactionDto> transactionsDtoList = new List<TransactionDto>();
            foreach (Transaction transaction in transactions)
            {
                transactionsDtoList.Add(new TransactionDto(transaction.CreatedOn,
                                                           transaction.Description,
                                                           transaction.Amount,
                                                           transaction.Type,
                                                           transaction.Type.ToString()));
            }

            return Results.Ok(transactionsDtoList);
        }).WithTags(TransactionEndpointSchema.TransactionTag);

        return endpointRouteBuilder;
    }
}
