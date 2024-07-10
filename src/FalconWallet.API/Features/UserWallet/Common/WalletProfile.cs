﻿using AutoMapper;
using FalconWallet.API.Features.UserWallet.CreateWallet;

namespace FalconWallet.API.Features.UserWallet.Common;

public class WalletProfile :Profile
{
    public WalletProfile()
    {
        CreateMap<Wallet, CreateWalletResponse>()
            .ForCtorParam("WalletId", opt => opt.MapFrom(src => src.Id));
    }
}