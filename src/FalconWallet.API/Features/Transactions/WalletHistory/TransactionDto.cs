using FalconWallet.API.Features.Transactions.Common;

namespace FalconWallet.API.Features.Transactions.WalletHistory;

public sealed record TransactionDto(DateTime CreatedOn,
                                    string? Description,
                                    decimal Amount,
                                    TransactionType Type,
                                    string TypeName);

