using AutoMapper;
using FalconWallet.API.Features.MultiCurrency.CreateCurrency;

namespace FalconWallet.API.Features.MultiCurrency.Common;

public class CurrencyProfile : Profile
{
    public CurrencyProfile()
    {
        CreateMap<Currency, CreateCurrencyResponse>();
    }
}
