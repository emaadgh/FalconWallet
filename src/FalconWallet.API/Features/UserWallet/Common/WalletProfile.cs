using AutoMapper;
using FalconWallet.API.Features.UserWallet.CreateWallet;
using FalconWallet.API.Features.UserWallet.GetWallet;

namespace FalconWallet.API.Features.UserWallet.Common;

public class WalletProfile : Profile
{
    public WalletProfile()
    {
        CreateMap<Wallet, CreateWalletResponse>()
            .ForCtorParam("WalletId", opt => opt.MapFrom(src => src.Id));

        CreateMap<Wallet, GetWalletResponse>()
            .ForCtorParam("Currency", opt => opt.MapFrom(src => src.Currency.Code));
    }
}
