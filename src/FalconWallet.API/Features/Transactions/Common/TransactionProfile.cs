using AutoMapper;
using FalconWallet.API.Features.Transactions.WalletHistory;

namespace FalconWallet.API.Features.Transactions.Common;

public class TransactionProfile : Profile
{
    public TransactionProfile()
    {
        CreateMap<Transaction, TransactionDto>()
            .ForCtorParam("TypeName", opt => opt.MapFrom(src => src.Type.ToString()));
    }
}
